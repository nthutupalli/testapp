/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTransferObjects
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// SubCategoryDto
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    public class SubCategoryDto
    {
        /// <summary>
        /// SubCategoryId
        /// </summary>
        [DataMember]
        public Int16 SubCategoryId { get; set; }

        /// <summary>
        /// SubCategoryName
        /// </summary>
        [DataMember]
        public string SubCategoryName { get; set; }

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
