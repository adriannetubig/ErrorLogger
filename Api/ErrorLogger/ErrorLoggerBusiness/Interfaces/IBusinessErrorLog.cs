using ErrorLoggerBusiness.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ErrorLoggerBusiness.Interfaces
{
    public interface IBusinessErrorLog
    {
        Task Create(CancellationToken cancellationToken, ExceptionLog exceptionLog, string applicationName);
        Task<List<ExceptionLog>> Read(CancellationToken cancellationToken);
    }
}
