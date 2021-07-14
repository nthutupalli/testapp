namespace Common.DataTransferObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// PolicyDrugs
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [ExcludeFromCodeCoverage]
    public class UpdateTypeDto
    {
        /// <summary>
        /// UpdateTypeId
        /// </summary>
        [DataMember]
        public int UpdateTypeId { get; set; }

        /// <summary>
        /// UpdateTypeName
        /// </summary>
        [DataMember]
        public string UpdateTypeName { get; set; }

    }
}
