using PaycomUz.Models.Requests;
using PaycomUz.Models.Responses;

namespace PaycomUz.Abstractions
{
    /// <summary>
    /// Контракт пользовательской логики для метода PerformTransaction.
    /// Вызывается, когда клиент подтверждает транзакцию.
    /// </summary>
    public interface IPerformTransactionHandler
    {
        Task<PaycomResponse> HandleAsync(PaycomRequest request);
    }
}
