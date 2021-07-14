using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common.DataTransferObjects
{
    [ExcludeFromCodeCoverage]
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
        public class NFMYBBatchUploadFileStatus
        {
            public string fileStatus { get; set; }
            public int policyTypeId { get; set; }
        }
        public class ApproveorRejectBatchUploadFile
        {
            public int fileId { get; set; }
            public string status { get; set; }
            public string actionBy { get; set; }
        }
        public class ApproveorRejectBatchArchiveFile
        {
            public int fileId { get; set; }
            public string status { get; set; }
            public string actionBy { get; set; }
            public string action { get; set; }
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
