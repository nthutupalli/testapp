
namespace Common.DataTransferObjects
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// PolicyClaimCodes
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    public class PolicyClaimCodeDto
    {
        /// <summary>
        /// ClaimCodeId
        /// </summary>
        [DataMember]
        public int ClaimCodeId { get; set; }

        /// <summary>
        /// ClaimCodeType
        /// </summary>
        [DataMember]
        public string ClaimCodeType { get; set; }

        /// <summary>
        /// ClaimCodeValue
        /// </summary>
        [DataMember]
        public string ClaimCodeValue { get; set; }

        /// <summary>
        /// ClaimCodeDesc
        /// </summary>
        [DataMember]
        public string ClaimCodeDesc { get; set; }

        /// <summary>
        /// ClaimCodeComments
        /// </summary>
        [DataMember]
        public string ClaimCodeComments { get; set; }

        /// <summary>
        /// ClaimCodeTypeText
        /// </summary>
        public string ClaimCodeTypeText { get; set; }
    }
}
