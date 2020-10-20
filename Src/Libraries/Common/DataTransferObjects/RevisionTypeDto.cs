namespace Common.DataTransferObjects
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// PolicyDrugs
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    public class RevisionTypeDto
    {
        /// <summary>
        /// RevisionTypeId
        /// </summary>
        [DataMember]
        public int RevisionTypeId { get; set; }

        /// <summary>
        /// RevisionType
        /// </summary>
        [DataMember]
        public string RevisionTypeName { get; set; }

        /// <summary>
        /// RevisionTypeIdName
        /// </summary>
        [DataMember]
        public string RevisionTypeIdName { get; set; }

    }
}
