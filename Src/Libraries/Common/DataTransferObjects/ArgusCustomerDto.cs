using System;
using System.Collections.Generic;
using System.Text;

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
