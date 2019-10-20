using ErrorLoggerData.Entitties;
using System.Threading;
using System.Threading.Tasks;

namespace ErrorLoggerData.Interfaces
{
    public interface IDataInnerExceptionLogs
    {
        Task<EntityInnerExceptionLog> Create(CancellationToken cancellationToken, EntityInnerExceptionLog entityInnerExceptionLog);
    }
}
