using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTransferObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Policy Template Dto
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PolicyTemplateDto
    {
        /// <summary>
        /// TemplateId
        /// </summary>
        public Int16 TemplateId { get; set; }

        /// <summary>
        /// PolicyTypeId
        /// </summary>
        public Constants.PolicyType PolicyType { get; set; }

        /// <summary>
        /// VersionControlDisclaimer
        /// </summary>
        public string VersionControlDisclaimer { get; set; }

        /// <summary>
        /// PolicyDisclaimer
        /// </summary>
        public string PolicyDisclaimer { get; set; }

        /// <summary>
        /// FooterDisClaimer
        /// </summary>
        public string FooterDisClaimer { get; set; }

        /// <summary>
        /// CdCompendium
        /// </summary>
        public string CdCompendium { get; set; }

        /// <summary>
        /// InternalOnlyDisclaimer
        /// </summary>
        public string InternalOnlyDisclaimer { get; set; }

        /// <summary>
        /// ExperimentalDisclaimer
        /// </summary>
        public string ExperimentalDisclaimer { get; set; }

        /// <summary>
        /// PrescriberInstructions
        /// </summary>
        public string PrescriberInstructions { get; set; }

       

        /// <summary>
        /// UpdatedBy
        /// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Background
        /// </summary>
        public string Background { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ProviderClaimsCode
        /// </summary>
        public string ProviderClaimCodes { get; set; }
    }
}
