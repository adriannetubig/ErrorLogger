using ErrorLoggerData.Entitties;
using ErrorLoggerData.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ErrorLoggerData.Services
{
    public class DataInnerExceptionLogs: IDataInnerExceptionLogs
    {
        private readonly string _connectionString;
        public DataInnerExceptionLogs(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<EntityInnerExceptionLog> Create(CancellationToken cancellationToken, EntityInnerExceptionLog entityInnerExceptionLog)
        {
            using (var context = new Context(_connectionString))
            {
                context.InnerExceptionLogs.Add(entityInnerExceptionLog);
                await context.SaveChangesAsync(cancellationToken);
                return entityInnerExceptionLog;
            }
        }
    }
}
