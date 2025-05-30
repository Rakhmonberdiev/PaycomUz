
using System.Text.Json.Serialization;

namespace PaycomUz.Models.Requests.Params
{
    /// <summary>
    /// Параметры метода CancelTransaction.
    /// Используется для отмены транзакции.
    /// </summary>
    public class CancelTransactionParams
    {
        /// <summary>
        /// Уникальный ID транзакции
        /// </summary>
        [JsonPropertyName("id")]
        public string TransactionId { get; set; } = string.Empty;

        /// <summary>
        /// Причина отмены (код, определяется системой)
        /// </summary>
        [JsonPropertyName("reason")]
        public int Reason { get; set; }
    }
}
