using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
            public Int32 lobId { get; set; }

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
    }
}
