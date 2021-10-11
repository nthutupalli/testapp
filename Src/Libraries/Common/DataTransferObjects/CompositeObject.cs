using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Common.DataTransferObjects
{
    public class CompositeObject
    {
        public class SaveCustomerClientMapping
        {
            [DataMember]
            public Collection<ArgusCustomerDto> ArgusCustomerDtoCollection { get; set; }
            [DataMember]
            public Collection<ArgusClientDto> ArgusClientDtoCollection { get; set; }
            [DataMember]
            public Int16 lobId { get; set; }
        }
        public class SaveRejectCodeMapping
        {
            public Collection<PolicyRejectCodeDto> policyRejectCodeCollection { get; set; }
            [DataMember]
            public Int16 policyTypeId { get; set; }
        }
        public class SelectedFormularies
        {
            [DataMember]
            public int planYear { get; set; }
            [DataMember]
            public int? lobId { get; set; }

        }
       
        public class LobValue
        {
            [DataMember]
            public Int16 lobId { get; set; }
        }
        public class PoliyOwnerIdValue
        {
            [DataMember]
            public Int16 PoliyOwnerId { get; set; }
        }
        public class therapeuticCategoryIdIdValue
        {
            [DataMember]
            public Int16 therapeuticCategoryId { get; set; }
        }
        public class subCategoryIdValue
        {
            [DataMember]
            public Int16 subCategoryId { get; set; }
        }
        public class AvailableRejectCodes
        {
            [DataMember]
            public Int16 policyTypeId { get; set; }
        }
    }
}
