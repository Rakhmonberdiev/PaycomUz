

using System.Text.Json.Serialization;

namespace PaycomUz.Models.Requests.Params
{
    /// <summary>
    /// Параметры метода CheckTransaction.
    /// Используется для получения информации о транзакции.
    /// </summary>
    public class CheckTransactionParams
    {
        /// <summary>
        /// Уникальный ID транзакции
        /// </summary>
        [JsonPropertyName("id")]
        public string TransactionId { get; set; } = string.Empty;
    }
}
