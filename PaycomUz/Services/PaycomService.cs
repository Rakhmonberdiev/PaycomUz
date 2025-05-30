
using PaycomUz.Abstractions;
using PaycomUz.Configuration;
using PaycomUz.Core.Errors;
using PaycomUz.Models.Enums;
using PaycomUz.Models.Errors;
using PaycomUz.Models.Requests;
using PaycomUz.Models.Requests.Params;
using PaycomUz.Models.Responses;
using System.Text.Json;

namespace PaycomUz.Services
{
    /// <summary>
    /// Реализация универсального обработчика запроса от Paycom.
    /// </summary>
    public class PaycomService : IPaycomService
    {
        private readonly ICheckPerformTransactionHandler _checkHandler;
        private readonly ICreateTransactionHandler _createHandler;
        private readonly IPerformTransactionHandler _performHandler;
        private readonly ICancelTransactionHandler _cancelHandler;
        private readonly ICheckTransactionHandler _checkTransactionHandler;
        private readonly IGetStatementHandler _getStatementHandler;
        public PaycomService(PaycomSettings options, ICheckPerformTransactionHandler checkHandler, ICreateTransactionHandler createHandler, IPerformTransactionHandler performHandler, ICancelTransactionHandler cancelHandler, ICheckTransactionHandler checkTransactionHandler, IGetStatementHandler getStatementHandler)
        {
            _checkHandler = checkHandler;
            _createHandler = createHandler;
            _performHandler = performHandler;
            _cancelHandler = cancelHandler;
            _checkTransactionHandler = checkTransactionHandler;
            _getStatementHandler = getStatementHandler;
        }

        public async Task<PaycomResponse> HandleAsync(PaycomRequest request)
        {
            return request.Method switch
            {
                PaycomMethods.CheckPerformTransaction => await HandleCheckPerformTransaction(request),
                PaycomMethods.CreateTransaction => await HandleCreateTransaction(request),
                PaycomMethods.PerformTransaction => await HandlePerformTransaction(request),
                PaycomMethods.CancelTransaction => await HandleCancelTransaction(request),
                PaycomMethods.CheckTransaction => await HandleCheckTransaction(request),
                PaycomMethods.GetStatement => await HandleGetStatment(request),
                _ => PaycomResponse.CreateError(-32601, "Метод не найден", request.Id)
            };
        }

        private async Task<PaycomResponse> HandleCheckPerformTransaction(PaycomRequest request)
        {
            return await _checkHandler.HandleAsync(request);
        }
        private async Task<PaycomResponse> HandleCreateTransaction(PaycomRequest request)
        {
            return await _createHandler.HandleAsync(request);
        }
        private async Task<PaycomResponse> HandlePerformTransaction(PaycomRequest request)
        {
            return await _performHandler.HandleAsync(request);
        }

        private async Task<PaycomResponse> HandleCancelTransaction(PaycomRequest request)
        {
            return await _cancelHandler.HandleAsync(request);
        }
        private async Task<PaycomResponse> HandleCheckTransaction(PaycomRequest request)
        {
            return await _checkTransactionHandler.HandleAsync(request);
        }
        private async Task<PaycomResponse> HandleGetStatment(PaycomRequest request)
        {
            return await _getStatementHandler.HandleAsync(request);
        }
    }
}
