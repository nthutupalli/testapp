/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/
using System;


namespace Common.DataTransferObjects
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// TherapeuticCategoryDto
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    public class TherapeuticCategoryDto
    {
        /// <summary>
        /// TherapeuticCategoryId
        /// </summary>
        [DataMember]
        public Int16 TherapeuticCategoryId { get; set; }

        /// <summary>
        /// TherapeuticCategoryName
        /// </summary>
        [DataMember]
        public string TherapeuticCategoryName { get; set; }

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
    }
}
