/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

namespace Common.DataTransferObjects
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// RuleLookBackPeriodDto
    /// </summary>
    public class RuleLookBackPeriodDto
    {
        /// <summary>
        /// LookBackId
        /// </summary>
        [DataMember]
        public Int16 LookBackId { get; set; }

        /// <summary>
        /// LookBackValue
        /// </summary>
        [DataMember]
        public string LookBackValue { get; set; }

        /// <summary>
        /// LookBackUnit
        /// </summary>
        [DataMember]
        public string LookBackUnit { get; set; }

        /// <summary>
        /// ActionType
        /// </summary>
        [DataMember]
        public Constants.ActionType ActionType { get; set; }

        /// <summary>
        /// UpdatedBy
        /// </summary>
        [DataMember]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// LookBackValueUnit
        /// </summary>
        [DataMember]
        public string LookBackValueUnit { get; set; }

        /// <summary>
        /// IsEditable
        /// </summary>
        [DataMember]
        public bool IsEditable { get; set; }
    }
}
