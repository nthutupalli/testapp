/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTransferObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// Policy Template Dto
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PolicyTemplateDto
    {
        /// <summary>
        /// TemplateId
        /// </summary>
        [DataMember]
        public Int16 TemplateId { get; set; }

        /// <summary>
        /// PolicyTypeId
        /// </summary>
        [DataMember]
        public Constants.PolicyType PolicyType { get; set; }

        /// <summary>
        /// VersionControlDisclaimer
        /// </summary>
        [DataMember]
        public string VersionControlDisclaimer { get; set; }

        /// <summary>
        /// PolicyDisclaimer
        /// </summary>
        [DataMember]
        public string PolicyDisclaimer { get; set; }

        /// <summary>
        /// FooterDisClaimer
        /// </summary>
        [DataMember]
        public string FooterDisClaimer { get; set; }

        /// <summary>
        /// CdCompendium
        /// </summary>
        [DataMember]
        public string CdCompendium { get; set; }

        /// <summary>
        /// InternalOnlyDisclaimer
        /// </summary>
        [DataMember]
        public string InternalOnlyDisclaimer { get; set; }

        /// <summary>
        /// ExperimentalDisclaimer
        /// </summary>
        [DataMember]
        public string ExperimentalDisclaimer { get; set; }

        /// <summary>
        /// PrescriberInstructions
        /// </summary>
        [DataMember]
        public string PrescriberInstructions { get; set; }



        /// <summary>
        /// UpdatedBy
        /// </summary>
        [DataMember]
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Background
        /// </summary>
        [DataMember]
        public string Background { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// ProviderClaimsCode
        /// </summary>
        [DataMember]
        public string ProviderClaimCodes { get; set; }
    }
}
