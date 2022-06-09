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
    /// PolicyDrugs
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    public class UpdateTypeDto
    {
        /// <summary>
        /// UpdateTypeId
        /// </summary>
        [DataMember]
        public int UpdateTypeId { get; set; }

        /// <summary>
        /// UpdateTypeName
        /// </summary>
        [DataMember]
        public string UpdateTypeName { get; set; }

    }
}
