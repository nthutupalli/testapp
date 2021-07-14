using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.DataTransferObjects
{
    [ExcludeFromCodeCoverage]
    public class PolicyTypeDto
    {
        /// <summary>
        /// Policy Type Id
        /// </summary>
        public Int16 PolicyTypeId { get; set; }

        /// <summary>
        /// Policy Type Name
        /// </summary>
        public string PolicyTypeName { get; set; }

        /// <summary>
        /// Action Type
        /// </summary>
        //public Constants.ActionType ActionType { get; set; }
    }
}
