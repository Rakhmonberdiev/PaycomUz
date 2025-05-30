
using PaycomUz.Models.Requests;
using PaycomUz.Models.Responses;

namespace PaycomUz.Abstractions
{
    /// <summary>
    /// Контракт пользовательской логики для метода CancelTransaction.
    /// Используется для отмены транзакции по ID.
    /// </summary>
    public interface ICancelTransactionHandler
    {
        Task<PaycomResponse> HandleAsync(PaycomRequest request);
    }
}
