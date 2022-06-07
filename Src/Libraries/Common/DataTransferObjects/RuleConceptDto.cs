/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        [DataMember]
        public Int16 ConceptId { get; set; }

        /// <summary>
        /// ConceptName
        /// </summary>
        [DataMember]
        public string ConceptName { get; set; }

        /// <summary>
        /// ConceptType
        /// </summary>
        [DataMember]
        public string ConceptType { get; set; }

        /// <summary>
        /// DateType
        /// </summary>
        [DataMember]
        public string DateType { get; set; }

        /// <summary>
        /// AnchorDate
        /// </summary>
        [DataMember]
        public string AnchorDate { get; set; }
    }
}
