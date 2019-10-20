using ErrorLoggerData.Entitties;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ErrorLoggerData.Interfaces
{
    public interface IDataExceptionLogs
    {
        Task<EntityExceptionLog> Create(CancellationToken cancellationToken, EntityExceptionLog entityExceptionLog);
        Task<List<EntityExceptionLog>> Read(CancellationToken cancellationToken);
    }
}
