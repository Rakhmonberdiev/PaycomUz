
using System.Text.Json.Serialization;

namespace PaycomUz.Models.Requests.Params
{
    /// <summary>
    /// Параметры метода CheckPerformTransaction.
    /// Используется для проверки, можно ли создать транзакцию.
    /// </summary>
    public class CheckPerformTransactionParams
    {
        /// <summary>
        /// Сумма транзакции (в тийинах)
        /// </summary>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Объект account, содержащий user_id или order_id (кастомный ключ)
        /// </summary>
        [JsonPropertyName("account")]
        public Dictionary<string, string> Account { get; set; } = new();
    }
}
