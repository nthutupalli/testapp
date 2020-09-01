using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalPolicyAdminAPI.Logging;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.VaultManager;

namespace ClinicalPolicyAdminAPI.Controllers
{
    [Route("api/Base")]
    [ApiController]
    public class BaseController : ControllerBase
    {

       
        public static void log(string errormessage,string LogEventTypeError,string LogSeverityLow)
        {
            ServiceLogging serviceLogging = new ServiceLogging();
            serviceLogging.EnterpriseLogging(errormessage, LogEventTypeError, LogSeverityLow);
           
        }
    }
}