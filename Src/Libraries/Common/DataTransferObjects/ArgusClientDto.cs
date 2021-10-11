using System;
using System.Collections.Generic;
using System.Text;

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
