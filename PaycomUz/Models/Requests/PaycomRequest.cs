using System.Text.Json.Serialization;
using System.Text.Json;

namespace PaycomUz.Models.Requests
{
    /// <summary>
    /// Входящий запрос от PaycomUz в формате JSON-RPC 2.0.
    /// Используется для всех методов: CheckPerform, Create, Perform, Cancel и т.д.
    /// </summary>
    public class PaycomRequest
    {
        /// <summary>
        /// Версия протокола JSON-RPC. Всегда "2.0".
        /// </summary>
        [JsonPropertyName("jsonrpc")]
        public string Jsonrpc { get; set; } = "2.0";


        /// <summary>
        /// Уникальный ID запроса, который нужно вернуть в ответе.
        /// Может быть числом или строкой, поэтому используется JsonElement.
        /// </summary>
        [JsonPropertyName("id")]
        public JsonElement Id { get; set; }

        /// <summary>
        /// Название вызываемого метода (например, "CreateTransaction").
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;

        /// <summary>
        /// Сырые параметры запроса. Нужно десериализовать вручную в нужный тип.
        /// </summary>
        [JsonPropertyName("params")]
        public JsonElement Params { get; set; }
    }
}
