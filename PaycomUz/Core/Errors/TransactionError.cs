using PaycomUz.Models.Common;
using PaycomUz.Models.Errors;

namespace PaycomUz.Core.Errors
{
    /// <summary>
    /// Ошибка, связанная с транзакциями Paycom.
    /// Используется при генерации ответа с ошибкой по спецификации Payme.
    /// </summary>
    public class TransactionError : BaseError
    {

        /// <summary>
        /// Код ошибки (например, -31003, -31008)
        /// </summary>
        public int TransactionErrorCode { get; }

        /// <summary>
        /// Локализованные сообщения об ошибке (uz/ru/en)
        /// </summary>
        public LocalizedMessage TransactionErrorMessage { get; }

        /// <summary>
        /// Дополнительные данные, возвращаемые в поле "data"
        /// </summary>
        public object? TransactionData { get; }

        /// <summary>
        /// Значение, переданное в поле "id"
        /// </summary>
        public object? TransactionId { get; }





        /// <summary>
        /// Конструктор ошибки. Используется внутри сервисов для выбрасывания исключения с деталями.
        /// </summary>
        /// <param name="error">Предопределённая ошибка PaymeError</param>
        /// <param name="id">ID запроса от клиента</param>
        /// <param name="data">Поле "data" из ответа Payme</param>
        /// <example>
        /// throw new TransactionError(PaymeError.InvalidAmount, id: request.Id, data: "amount");
        /// </example>

        public TransactionError(PaymeError error, object? id = null, object? data = null): base(400, error.Message.En, null, error.Name, 400)
        {
            TransactionErrorCode = error.Code;
            TransactionErrorMessage = error.Message;
            TransactionData = data;
            TransactionId = id;
        }
    }
}
