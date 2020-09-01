using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static ClinicalPolicyAdminAPI.Logging.EnterpriseLogRequest;

namespace ClinicalPolicyAdminAPI.Logging
{
    public class ServiceLogging
    {
        //EL2.0 Method
        public void EnterpriseLogging(string ermessage, string logEventTypeCode, string severityCode)
        {

            string elUrl = ConfigurationManager.AppSettings["EnterpriseLoggingUrl"].ToString();
            DateTime date = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "Eastern Standard Time");

            LogMetaData metaData = new LogMetaData
            {
                LogEventTypeCode = logEventTypeCode,
                LogSeverityCode = severityCode,
                LogEventDateTime = Convert.ToDateTime(date.ToString("s", CultureInfo.InvariantCulture), CultureInfo.InvariantCulture)
            };

            ErrorLogEvent logEvent = new ErrorLogEvent { LogMetaData = new LogMetaData() };
            logEvent.LogMetaData = metaData;
            SourceApplicationInformation sourceInfo = new SourceApplicationInformation
            {
                EAPMId = Convert.ToInt32(ConfigurationManager.AppSettings["EAPM"].ToString(), CultureInfo.InvariantCulture),
                HostMachineName = Environment.MachineName,
                HostEnvironmentName = ConfigurationManager.AppSettings["ENVIRONMENT"].ToString(),
                CorrelationId = Convert.ToString(Guid.NewGuid(), CultureInfo.InvariantCulture)
            };
            logEvent.SourceApplicationInformation = new SourceApplicationInformation();
            logEvent.SourceApplicationInformation = sourceInfo;
            ErrorInformation errorInfo = new ErrorInformation
            {
                ErrorCode = Constants.ErrorMessage.ErrorCode,
                ErrorDescription = ermessage
            };
            logEvent.ErrorInformation = new ErrorInformation();
            logEvent.ErrorInformation = errorInfo;

            ErrorRequest loggerRequest = new ErrorRequest { LogEvent = new Collection<ErrorLogEvent> { logEvent } };
            dynamic request = new
            {
                Request = loggerRequest
            };
            string jsonErrorRequest = JsonConvert.SerializeObject(request);
            try
            {
                HttpContent ercontent = new StringContent(jsonErrorRequest);
                // ReSharper disable once UnusedVariable
                HttpResponseMessage response = AysncLog(elUrl, ercontent).Result;

            }
            catch (Exception ex)
            {
                // ReSharper disable once UnusedVariable
                string msg = ex.Message;
            }
        }

        internal void EnterpriseLogging(object message, object logEventTypeError, object logSeverityLow)
        {
            throw new NotImplementedException();
        }

        private async Task<HttpResponseMessage> AysncLog(string requestUrl, HttpContent httpContent)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await httpClient.PostAsync(requestUrl, httpContent).ConfigureAwait(false);
            }
            catch (HttpRequestException hre)
            {
                // ReSharper disable once UnusedVariable
                string msg = hre.Message;
            }
            return (response);
        }
    }
}
