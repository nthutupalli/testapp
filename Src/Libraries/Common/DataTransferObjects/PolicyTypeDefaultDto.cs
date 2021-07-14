using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.DataTransferObjects
{
    /// <summary>
    /// PolicyTypeDefaultDto
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PolicyTypeDefaultDto
    {
        /// <summary>
        /// PolicyType
        /// </summary>
        public Constants.PolicyType PolicyType { get; set; }

        /// <summary>
        /// ScenarioType
        /// </summary>
        public Constants.ScenarioType ScenarioType { get; set; }

        /// <summary>
        /// DefaultText
        /// </summary>
        public string DefaultText { get; set; }
    }
}
