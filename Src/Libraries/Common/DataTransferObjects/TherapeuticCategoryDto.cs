using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTransferObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// TherapeuticCategoryDto
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [ExcludeFromCodeCoverage]
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
