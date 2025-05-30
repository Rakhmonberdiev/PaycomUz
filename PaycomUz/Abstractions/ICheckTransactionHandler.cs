using PaycomUz.Models.Requests;
using PaycomUz.Models.Responses;

namespace PaycomUz.Abstractions
{
    public interface ICheckTransactionHandler
    {
        Task<PaycomResponse> HandleAsync(PaycomRequest request);
    }
}
