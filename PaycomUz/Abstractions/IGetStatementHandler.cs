using PaycomUz.Models.Requests;
using PaycomUz.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycomUz.Abstractions
{
    /// <summary>
    /// Контракт пользовательской логики для метода GetStatement.
    /// Возвращает список транзакций между двумя временными метками.
    /// </summary>
    public interface IGetStatementHandler
    {
        Task<PaycomResponse> HandleAsync(PaycomRequest request);
    }
}
