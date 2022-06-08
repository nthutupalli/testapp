/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/


using System.Runtime.Serialization;


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
