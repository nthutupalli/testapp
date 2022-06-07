/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

namespace Common.DataTransferObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// PolicyDrugs
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [ExcludeFromCodeCoverage]
    public class RevisionTypeDto
    {
        /// <summary>
        /// RevisionTypeId
        /// </summary>
        [DataMember]
        public int RevisionTypeId { get; set; }

        /// <summary>
        /// RevisionType
        /// </summary>
        [DataMember]
        public string RevisionTypeName { get; set; }

        /// <summary>
        /// RevisionTypeIdName
        /// </summary>
        [DataMember]
        public string RevisionTypeIdName { get; set; }

    }
}
