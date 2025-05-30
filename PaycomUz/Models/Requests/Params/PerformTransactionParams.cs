
using System.Text.Json.Serialization;

namespace PaycomUz.Models.Requests.Params
{
    /// <summary>
    /// Параметры метода PerformTransaction.
    /// Используется для выполнения транзакции (после создания).
    /// </summary>
    public class PerformTransactionParams
    {
        /// <summary>
        /// Уникальный ID транзакции (который пришёл в CreateTransaction)
        /// </summary>
        [JsonPropertyName("id")]
        public string TransactionId { get; set; } = string.Empty;
    }
}
