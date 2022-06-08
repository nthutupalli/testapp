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
    /// PolicyRejectCodeDto
    /// </summary>
    public class PolicyRejectCodeDto
    {
        /// <summary>
        /// RejectCodeId
        /// </summary>
        [DataMember]
        public int RejectCodeId { get; set; }

        /// <summary>
        /// RejectCode
        /// </summary>
        [DataMember]
        public string RejectCode { get; set; }

        /// <summary>
        /// RejectCodeDesc
        /// </summary>
        [DataMember]
        public string RejectCodeDesc { get; set; }

        /// <summary>
        /// ActionType
        /// </summary>
        [DataMember]
        public Constants.ActionType ActionType { get; set; }

        /// <summary>
        /// IsMapped
        /// </summary>
        [DataMember]
        public bool IsMapped { get; set; }

        /// <summary>
        /// RejectCodeWithDescription
        /// </summary>
        [DataMember]
        public string RejectCodeWithDescription { get { return RejectCode + "-" + RejectCodeDesc; } }

        /// <summary>
        /// UpdatedBy
        /// </summary>
        [DataMember]
        public string UpdatedBy { get; set; }
    }
}
