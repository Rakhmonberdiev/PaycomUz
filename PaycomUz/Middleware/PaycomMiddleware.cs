using Microsoft.AspNetCore.Http;
using PaycomUz.Abstractions;
using PaycomUz.Configuration;
using PaycomUz.Core.Errors;
using PaycomUz.Models.Errors;
using PaycomUz.Models.Requests;
using PaycomUz.Models.Responses;
using System.Text;
using System.Text.Json;
namespace PaycomUz.Middleware
{
    /// <summary>
    /// Основной middleware для обработки запросов от PaycomUz.
    /// Содержит авторизацию и полную JSON-RPC обработку.
    /// </summary>
    public class PaycomMiddleware
    {
        private readonly RequestDelegate _next;
        public PaycomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IPaycomService paycomService, PaycomSettings settings)
        {
            if (!context.Request.Path.StartsWithSegments("/api/paycom"))
            {
                await _next(context);
                return;
            }
            context.Response.ContentType = "application/json";

            try
            {
                if (!context.Request.Headers.TryGetValue("Authorization", out var authHeader) ||
                    !authHeader.ToString().StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                {
                    throw new TransactionError(PaymeError.InvalidAuthorization, await ExtractRpcId(context.Request));
                }
                var token = authHeader.ToString().Substring("Basic ".Length).Trim();
                var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var parts = decoded.Split(':', 2);
                if (parts.Length != 2 || parts[0] != settings.MerchantLogin || parts[1] != settings.MerchantKey)
                {
                    throw new TransactionError(PaymeError.InvalidAuthorization, await ExtractRpcId(context.Request));
                }

                await _next(context);
            }
            catch (TransactionError ex)
            {
                context.Response.StatusCode = 200;

                var response = new PaycomResponse
                {
                    Id = ex.TransactionId is JsonElement el ? el : JsonDocument.Parse("null").RootElement,
                    Error = new
                    {
                        code = ex.TransactionErrorCode,
                        message = new
                        {
                            ru = ex.TransactionErrorMessage.Ru,
                            uz = ex.TransactionErrorMessage.Uz,
                            en = ex.TransactionErrorMessage.En
                        },
                        data = ex.TransactionData
                    }
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }

        }
        private static async Task<object?> ExtractRpcId(HttpRequest request)
        {
            request.EnableBuffering();
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;

            using var doc = JsonDocument.Parse(body);
            if (doc.RootElement.TryGetProperty("id", out var idEl))
            {
                return idEl.ValueKind switch
                {
                    JsonValueKind.Number => idEl.GetInt64(),
                    JsonValueKind.String => idEl.GetString(),
                    _ => null
                };
            }

            return null;
        }
    }
}
