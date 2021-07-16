using System;
using System.Collections.ObjectModel;

namespace Common.DataTransferObjects
{
    public class CompositeObject
    {
        public class SaveCustomerClientMapping
        {
            public Collection<ArgusCustomerDto> ArgusCustomerDtoCollection { get; set; }
            public Collection<ArgusClientDto> ArgusClientDtoCollection { get; set; }
            public Int16 lobId { get; set; }
        }
        public class SaveRejectCodeMapping
        {
            public Collection<PolicyRejectCodeDto> policyRejectCodeCollection { get; set; }
            public Int16 policyTypeId { get; set; }
        }
        public class SelectedFormularies
        {
            public int planYear { get; set; }
            public int? lobId { get; set; }

        }
       
        public class LobValue
        {
            public Int16 lobId { get; set; }
        }
        public class PoliyOwnerIdValue
        {
            public Int16 PoliyOwnerId { get; set; }
        }
        public class therapeuticCategoryIdIdValue
        {
            public Int16 therapeuticCategoryId { get; set; }
        }
        public class subCategoryIdValue
        {
            public Int16 subCategoryId { get; set; }
        }
        public class AvailableRejectCodes
        {
            public Int16 policyTypeId { get; set; }
        }
    }
}
