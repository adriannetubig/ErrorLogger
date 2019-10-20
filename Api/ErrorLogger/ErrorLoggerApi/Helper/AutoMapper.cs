using AutoMapper;
using ErrorLoggerBusiness.Models;
using ErrorLoggerData.Entitties;

namespace ErrorLoggerApi.Helper
{
    public static class AutoMapper
    {
        public static IMapper Config()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<ExceptionLog, EntityExceptionLog>().ReverseMap();
                mc.CreateMap<InnerExceptionLog, EntityInnerExceptionLog>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}
