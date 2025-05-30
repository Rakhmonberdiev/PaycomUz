

namespace PaycomUz.Core.Errors
{
    /// <summary>
    /// Базовый класс ошибок для кастомных исключений.
    /// Используется для оборачивания ошибок в единую модель.
    /// </summary>
    public class BaseError : Exception
    {
        /// <summary>
        /// HTTP-статус ошибки (например, 400 или 500)
        /// </summary>
        public int Status { get; }
        /// <summary>
        /// Дополнительные сообщения об ошибке (валидация и т.д.)
        /// </summary>
        public IEnumerable<string>? Errors { get; }


        /// <summary>
        /// Название ошибки (например, InvalidAmount)
        /// </summary>
        public string ErrorName { get; }

        /// <summary>
        /// Код ошибки Payme или API
        /// </summary>
        public int? StatusCode { get; }


        public BaseError(int status, string message, IEnumerable<string>? errors = null, string? name = null, int? statusCode = null) : base(message)
        {
            Status = status;
            Errors = errors;
            ErrorName = name ?? "BaseError";
            StatusCode = statusCode;
        }
    }
}
