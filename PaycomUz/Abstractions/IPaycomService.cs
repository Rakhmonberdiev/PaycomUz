
using PaycomUz.Models.Requests;
using PaycomUz.Models.Responses;

namespace PaycomUz.Abstractions
{
    public interface IPaycomService
    {
        /// <summary>
        /// Обрабатывает входящий JSON-RPC запрос от Paycom.
        /// Метод определяет нужную операцию по request.Method.
        /// </summary>
        /// <param name="request">Входящий JSON-RPC запрос</param>
        /// <returns>Ответ в формате JSON-RPC (PaycomResponse)</returns>
        Task<PaycomResponse> HandleAsync(PaycomRequest request);
    }
}
