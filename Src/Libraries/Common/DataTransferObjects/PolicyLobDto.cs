/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using System.Runtime.Serialization;
using System;


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

        [DataMember]
        public string LobSubCategory { get; set; }


        [DataMember]
        public string PrimaryLobSubCategory { get; set; }
    }
}

