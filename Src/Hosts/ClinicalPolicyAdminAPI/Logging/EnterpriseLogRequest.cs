﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalPolicyAPI.Logging
{
    [ExcludeFromCodeCoverage]
    class EnterpriseLogRequest
    {
        //LogMetaData
        public class LogMetaData
        {
            public string LogEventTypeCode { get; set; }
            public string LogSeverityCode { get; set; }
            public DateTime LogEventDateTime { get; set; }

        }

        public class SourceApplicationInformation
        {
            public int EAPMId { get; set; }
            public string HostMachineName { get; set; }
            public string HostEnvironmentName { get; set; }
            public string CorrelationId { get; set; }
        }
        public class ErrorInformation
        {
            public string ErrorCode { get; set; }
            public string ErrorDescription { get; set; }

        }
        public class ErrorLogEvent
        {
            public LogMetaData LogMetaData { get; set; }
            public SourceApplicationInformation SourceApplicationInformation { get; set; }
            public ErrorInformation ErrorInformation { get; set; }
        }
        public class ErrorRequest
        {
            public Collection<ErrorLogEvent> LogEvent { get; set; }
        }
    }
}
