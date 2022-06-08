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
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// ArgusCustomerDto
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ArgusCustomerDto
    {
        /// <summary>
        /// CustomerId
        /// </summary>
        [DataMember]
        public Int16 CustomerId { get; set; }

        /// <summary>
        /// CustomerCode
        /// </summary>
        [DataMember]
        public string CustomerCode { get; set; }

        /// <summary>
        /// IsMapped
        /// </summary>
        [DataMember]
        public bool IsMapped { get; set; }

        /// <summary>
        /// ActionType
        /// </summary>
        [DataMember]
        public Constants.ActionType ActionType { get; set; }
    }
}
