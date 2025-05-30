
using PaycomUz.Models.Requests;
using PaycomUz.Models.Responses;

namespace PaycomUz.Abstractions
{
    /// <summary>
    /// Контракт для реализации пользовательской логики в методе CheckPerformTransaction.
    /// Позволяет самостоятельно обрабатывать account, user, order и т.д.
    /// </summary>
    public interface ICheckPerformTransactionHandler
    {
        Task<PaycomResponse> HandleAsync(PaycomRequest request);
    }
}
