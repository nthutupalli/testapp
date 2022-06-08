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
    /// ArgusClientDto
    /// </summary>
    public class ArgusClientDto
    {
        /// <summary>
        /// ClientId
        /// </summary>
        [DataMember]
        public Int16 ClientId { get; set; }

        /// <summary>
        /// ClientCode
        /// </summary>
        [DataMember]
        public string ClientCode { get; set; }

        /// <summary>
        /// CustomerId
        /// </summary>
        [DataMember]
        public Int16 CustomerId { get; set; }

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
