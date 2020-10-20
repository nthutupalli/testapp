﻿
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.DataTransferObjects
{

    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Policy Lob Dto
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    public class PolicyLobDto
    {
        /// <summary>
        /// Line Of Business Id
        /// </summary>
        [DataMember]
        public Int16 LobId { get; set; }

        /// <summary>
        /// Line Of Business Name
        /// </summary>
        [DataMember]
        public string LobName { get; set; }

        /// <summary>
        /// Action Type
        /// </summary>
        [DataMember]
        public Constants.ActionType ActionType { get; set; }

        /// <summary>
        /// UpdatedBy
        /// </summary>
        [DataMember]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// LobCode
        /// </summary>
        [DataMember]
        public Int16 LobCode { get; set; }

        /// <summary>
        /// Line Of Business Name
        /// </summary>
        [DataMember]
        public string LineOfBusinessIdName { get; set; }
        [DataMember]
        public bool IsActive { get; set; }


        [DataMember]
        public string Status { get; set; }
    }
}
