using ErrorLoggerBusiness.Interfaces;
using ErrorLoggerBusiness.Services;
using ErrorLoggerData.Interfaces;
using ErrorLoggerData.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorLoggerApi.Helper
{
    public static class Dependency
    {
        public static void SetDependency(ref IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDataExceptionLogs>(a => new DataExceptionLogs(connectionString));
            services.AddScoped<IDataInnerExceptionLogs>(a => new DataInnerExceptionLogs(connectionString));

            services.AddScoped<IBusinessErrorLog, BusinessErrorLog>();
        }
    }
}
