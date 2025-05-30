
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PaycomUz.Models.Responses
{
    /// <summary>
    /// Ответ от сервера в формате JSON-RPC 2.0.
    /// Возвращается в ответ на PaycomRequest.
    /// </summary>
    public class PaycomResponse
    {
        /// <summary>
        /// Версия протокола JSON-RPC. Всегда "2.0".
        /// </summary>
        [JsonPropertyName("jsonrpc")]
        public string Jsonrpc { get; set; } = "2.0";
        
        /// <summary>
        /// Результат выполнения метода. Используется, если запрос был успешным.
        /// </summary>
        [JsonPropertyName("result")]
        public object? Result { get; set; }
        
        /// <summary>
        /// Информация об ошибке. Используется, если произошла ошибка.
        /// </summary>
        [JsonPropertyName("error")]
        public object? Error { get; set; }
        
        /// <summary>
        /// ID, который пришёл в запросе, возвращается обратно.
        /// </summary>
        [JsonPropertyName("id")]
        public JsonElement Id { get; set; }


        /// <summary>
        /// Создание успешного ответа с результатом.
        /// </summary>
        /// <param name="id">ID из запроса</param>
        /// <param name="result">Результат выполнения</param>
        public static PaycomResponse CreateResult(JsonElement id, object result)
        {
            return new PaycomResponse
            {
                Id = id,
                Result = result,
                Error = null
            };
        }



        /// <summary>
        /// Создание ответа с ошибкой.
        /// </summary>
        /// <param name="code">Код ошибки по документации Paycom</param>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="id">ID из запроса</param>
        /// <param name="data">Доп. информация (необязательно)</param>
        /// 

        public static PaycomResponse CreateError(int code, string message, JsonElement id, string? data = null)
        {
            return new PaycomResponse
            {
                Id = id,
                Error = new
                {
                    code,
                    message = new
                    {
                        ru = message,
                        uz = message,
                        en = message
                    },
                    data
                },
                Result = null
            };
        }
    }
}
