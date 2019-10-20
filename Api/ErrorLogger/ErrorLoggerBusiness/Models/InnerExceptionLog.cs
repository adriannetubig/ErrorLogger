using System.Text.Json.Serialization;

namespace ErrorLoggerBusiness.Models
{
    public class InnerExceptionLog : ExceptionLog
    {
        public int InnerExceptionLogId { get; set; }
        [JsonIgnore]
        public override string ApplicationName { get; set; }
    }
}
