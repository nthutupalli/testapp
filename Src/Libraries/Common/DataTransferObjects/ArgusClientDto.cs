using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTransferObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// ArgusClientDto
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ArgusClientDto
    {
        /// <summary>
        /// ClientId
        /// </summary>
        public Int16 ClientId { get; set; }

        /// <summary>
        /// ClientCode
        /// </summary>
        public string ClientCode { get; set; }

        /// <summary>
        /// CustomerId
        /// </summary>
        public Int16 CustomerId { get; set; }

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
