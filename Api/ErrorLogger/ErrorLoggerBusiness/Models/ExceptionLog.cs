﻿using System;
using System.Text.Json.Serialization;

namespace ErrorLoggerBusiness.Models
{
    public class ExceptionLog
    {
        public int ExceptionLogId { get; set; }
        public virtual string ApplicationName { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public int HResult { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        [JsonPropertyName("InnerException")]
        public InnerExceptionLog InnerExceptionLog { get; set; }
    }
}
