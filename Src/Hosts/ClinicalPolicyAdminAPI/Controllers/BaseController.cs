/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/
/* 
 * Base Controller
 */
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
