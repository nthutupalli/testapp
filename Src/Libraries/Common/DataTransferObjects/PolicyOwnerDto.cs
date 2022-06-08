
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
    /// Policy Owner
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    public class PolicyOwnerDto
    {
        /// <summary>
        /// Policy Owner Id
        /// </summary>
        [DataMember]
        public Int16 PolicyOwnerId { get; set; }

        /// <summary>
        /// Owner Name
        /// </summary>
        [DataMember]
        public string OwnerName { get; set; }

        /// <summary>
        /// Owner Email
        /// </summary>
        [DataMember]
        public string OwnerEmail { get; set; }

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


        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string Status { get; set; }

    }

}

