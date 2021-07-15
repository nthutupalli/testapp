using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTransferObjects
{
    /// <summary>
    /// RuleConceptDto
    /// </summary>
    public class RuleConceptDto
    {
        /// <summary>
        /// ConceptId
        /// </summary>
        public Int16 ConceptId { get; set; }

        /// <summary>
        /// ConceptName
        /// </summary>
        public string ConceptName { get; set; }

        /// <summary>
        /// ConceptType
        /// </summary>
        public string ConceptType { get; set; }

        /// <summary>
        /// DateType
        /// </summary>
        public string DateType { get; set; }

        /// <summary>
        /// AnchorDate
        /// </summary>
        public string AnchorDate { get; set; }
    }
}
