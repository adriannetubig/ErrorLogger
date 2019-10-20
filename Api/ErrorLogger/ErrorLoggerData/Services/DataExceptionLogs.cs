using ErrorLoggerData.Entitties;
using ErrorLoggerData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErrorLoggerData.Services
{
    public class DataExceptionLogs : IDataExceptionLogs
    {
        private readonly string _connectionString;
        public DataExceptionLogs(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<EntityExceptionLog> Create(CancellationToken cancellationToken, EntityExceptionLog entityExceptionLog)
        {
            using (var context = new Context(_connectionString))
            {
                context.ExceptionLogs.Add(entityExceptionLog);
                await context.SaveChangesAsync(cancellationToken);
                return entityExceptionLog;
            }
        }
        public async Task<List<EntityExceptionLog>> Read(CancellationToken cancellationToken)
        {
            using (var context = new Context(_connectionString))
                return await context.ExceptionLogs.OrderByDescending(a => a.CreatedDateUtc).Include(a => a.InnerExceptionLog).ToListAsync(cancellationToken);
        }
    }
}
