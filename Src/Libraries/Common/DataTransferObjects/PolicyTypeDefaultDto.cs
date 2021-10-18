using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.DataTransferObjects
{
    /// <summary>
    /// PolicyTypeDefaultDto
    /// </summary>
    public class PolicyTypeDefaultDto
    {
        /// <summary>
        /// PolicyType
        /// </summary>
        [DataMember]
        public Constants.PolicyType PolicyType { get; set; }

        /// <summary>
        /// ScenarioType
        /// </summary>
        [DataMember]
        public Constants.ScenarioType ScenarioType { get; set; }

        /// <summary>
        /// DefaultText
        [DataMember]
        /// </summary>
        public string DefaultText { get; set; }
    }
}
