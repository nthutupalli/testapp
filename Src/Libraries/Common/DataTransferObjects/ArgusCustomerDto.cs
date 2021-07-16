using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTransferObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// ArgusCustomerDto
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ArgusCustomerDto
    {
        /// <summary>
        /// CustomerId
        /// </summary>
        public Int16 CustomerId { get; set; }

        /// <summary>
        /// CustomerCode
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// IsMapped
        /// </summary>
        public bool IsMapped { get; set; }

        /// <summary>
        /// ActionType
        /// </summary>
        public Constants.ActionType ActionType { get; set; }
    }
}
