using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.DataTransferObjects
{
    /// <summary>
    /// PolicyRejectCodeDto
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PolicyRejectCodeDto
    {
        /// <summary>
        /// RejectCodeId
        /// </summary>
        public int RejectCodeId { get; set; }

        /// <summary>
        /// RejectCode
        /// </summary>
        public string RejectCode { get; set; }

        /// <summary>
        /// RejectCodeDesc
        /// </summary>
        public string RejectCodeDesc { get; set; }

        /// <summary>
        /// ActionType
        /// </summary>
        public Constants.ActionType ActionType { get; set; }

        /// <summary>
        /// IsMapped
        /// </summary>
        public bool IsMapped { get; set; }

        /// <summary>
        /// RejectCodeWithDescription
        /// </summary>
        public string RejectCodeWithDescription { get { return RejectCode + "-" + RejectCodeDesc; } }

        /// <summary>
        /// UpdatedBy
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
