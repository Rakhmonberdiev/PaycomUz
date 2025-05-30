
using PaycomUz.Models.Requests;
using PaycomUz.Models.Responses;

namespace PaycomUz.Abstractions
{
    /// <summary>
    /// Контракт пользовательской логики для обработки CreateTransaction.
    /// Позволяет кастомно обрабатывать ID, account и amount.
    /// </summary>
    public interface ICreateTransactionHandler
    {
        Task<PaycomResponse> HandleAsync(PaycomRequest request);
    }
}
