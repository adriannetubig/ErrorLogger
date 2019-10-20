using AutoMapper;
using ErrorLoggerBusiness.Interfaces;
using ErrorLoggerBusiness.Models;
using ErrorLoggerData.Entitties;
using ErrorLoggerData.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ErrorLoggerBusiness.Services
{
    public class BusinessErrorLog: IBusinessErrorLog
    {
        private readonly IDataExceptionLogs _iDataExceptionLogs;
        private readonly IDataInnerExceptionLogs _iDataInnerExceptionLogs;
        private readonly IMapper _iMapper;

        public BusinessErrorLog(IMapper iMapper, IDataExceptionLogs iDataExceptionLogs, IDataInnerExceptionLogs iDataInnerExceptionLogs)
        {
            _iMapper = iMapper;
            _iDataExceptionLogs = iDataExceptionLogs;
            _iDataInnerExceptionLogs = iDataInnerExceptionLogs;
        }

        public async Task Create(CancellationToken cancellationToken, ExceptionLog exceptionLog, string applicationName)
        {
            var entityExceptionLog = _iMapper.Map<EntityExceptionLog>(exceptionLog);
            entityExceptionLog.ApplicationName = applicationName;
            entityExceptionLog.CreatedDateUtc = DateTime.UtcNow;

            if (entityExceptionLog.InnerExceptionLog != null)
            {
                entityExceptionLog.InnerExceptionLog.CreatedDateUtc = DateTime.UtcNow;
                entityExceptionLog.InnerExceptionLog.ExceptionLogId = entityExceptionLog.ExceptionLogId;
            }

            await _iDataExceptionLogs.Create(cancellationToken, entityExceptionLog);
        }

        public async Task<List<ExceptionLog>> Read(CancellationToken cancellationToken)
        {
           var entityExceptionLogs = await _iDataExceptionLogs.Read(cancellationToken);
            return _iMapper.Map<List<ExceptionLog>>(entityExceptionLogs);
        }
    }
}
