/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/
/*
 * Enterprise
 * Log
 * Request
 * Method
 */
using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

//Logging

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
            public int EapmId { get; set; }
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
