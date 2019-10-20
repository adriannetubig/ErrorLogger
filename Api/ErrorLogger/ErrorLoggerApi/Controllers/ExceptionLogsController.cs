using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ErrorLoggerBusiness.Interfaces;
using ErrorLoggerBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace ErrorLoggerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExceptionLogsController : ControllerBase
    {
        private readonly IBusinessErrorLog _iBusinessErrorLog;
        public ExceptionLogsController(IBusinessErrorLog iBusinessErrorLog)
        {
            _iBusinessErrorLog = iBusinessErrorLog;
        }

        [HttpPut("{applicationName}")]
        public async Task<IActionResult> Create(ExceptionLog exceptionLog, string applicationName)
        {
            await _iBusinessErrorLog.Create(default, exceptionLog, applicationName); //We will log the issue regardless if the request was cancelled
            return new ObjectResult(null)
            {
                StatusCode = (int)HttpStatusCode.Created
            };
        }

        [HttpGet("")]
        public async Task<IActionResult> Read(CancellationToken cancellationToken)
        {
           return Ok(await _iBusinessErrorLog.Read(cancellationToken));
        }
    }
}
