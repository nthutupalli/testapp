using ClinicalPolicyAPI.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ClinicalPolicyAdminAPI.Controllers
{
    [Route("api/Base")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        public static void log(string errormessage, string LogEventTypeError, string LogSeverityLow, IConfiguration config)
        {
            ServiceLogging serviceLogging = new ServiceLogging(config);
            serviceLogging.EnterpriseLogging(errormessage, LogEventTypeError, LogSeverityLow);

        }
    }
}