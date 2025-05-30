
using System.Text.Json.Serialization;

namespace PaycomUz.Models.Requests.Params
{
    /// <summary>
    /// Параметры метода CreateTransaction.
    /// Используется для создания транзакции.
    /// </summary>
    public class CreateTransactionParams
    {
        /// <summary>
        /// Уникальный ID транзакции со стороны Payme (для проверки дубликатов)
        /// </summary>
        [JsonPropertyName("id")]
        public string TransactionId { get; set; } = string.Empty;

        /// <summary>
        /// Время создания транзакции (в миллисекундах)
        /// </summary>
        [JsonPropertyName("time")]
        public long Time { get; set; }

        /// <summary>
        /// Сумма транзакции (в тийинах)
        /// </summary>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }


        /// <summary>
        /// Уникальные данные пользователя (например, ID заказа)
        /// </summary>
        [JsonPropertyName("account")]
        public Dictionary<string, string> Account { get; set; } = new();
    }
}
