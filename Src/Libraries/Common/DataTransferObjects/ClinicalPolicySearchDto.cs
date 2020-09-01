using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.DataTransferObjects
{
 
    public class ClinicalPolicySearchDto
    {
        private List<PublishStatusDto> publishStatusDto;

   
        public string PolicyName { get; set; }
        public Constants.PolicyType PolicyType { get; set; }
        public string PolicyTypeName { get; set; }
        public string LineOfBusiness { get; set; }
        public string DrugName { get; set; }
        public string PublishStatusList { get; set; }
        public string TherapeuticCategory { get; set; }
        public List<PublishStatusDto> PublishStatus
        {
            get { return publishStatusDto ?? (publishStatusDto = new List<PublishStatusDto>()); }
            set { publishStatusDto = value; }
        }
        public string SubCategory { get; set; }
        public DateTime? EffectiveStartDate { get; set; }
        public DateTime? EffectiveEndDate { get; set; }
        public DateTime? SendOnStartDate { get; set; }
        public DateTime? SendOnEndDate { get; set; }
        public DateTime? RevisionStartDate { get; set; }
        public DateTime? RevisionEndDate { get; set; }
        public DateTime? ReviewStartDate { get; set; }
        public DateTime? ReviewEndDate { get; set; }
        public DateTime? ApprovalStartDate { get; set; }
        public DateTime? ApprovalEndDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string PublishPath { get; set; }
        public string TitleDescription { get; set; }
        public DateTime? RetirementDate { get; set; }
        public Int32 Version { get; set; }
        public Constants.PolicyStatus Status { get; set; }

        public Int32 PolicyId { get; set; }
        public string InternalOnly { get; set; }
        public int IsDestinationChanged { get; set; }
        public string PolicyOwner { get; set; }
        public string RevisionId { get; set; }
        public Constants.RuleStatus RuleStatus { get; set; }
        public int IsPolicySentToTI { get; set; }
        public DateTime? RulesManualArchivalDate { get; set; }
        public bool HasOtherRevisions { get; set; }
        public bool IsMaximumActiveVersion { get; set; }
        public DateTime? MentorPublishOn { get; set; }
        public string MentorPublishBy { get; set; }
        public DateTime? WebPublishOn { get; set; }
        public string WebPublishBy { get; set; }
        public bool IsInternalOnly { get; set; }
        public bool PublishFlag { get; set; }
        public string Diagnosis { get; set; }
        public string Alternative { get; set; }
        public string PublishIndicator { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string RevisionNotes { get; set; }
        public bool IsTrackChangesRequired { get; set; }
        public DateTime? MentorRemovalOn { get; set; }
        public string MentorRemovalBy { get; set; }
        public DateTime? WebRemovalOn { get; set; }
        public DateTime SendOn { get; set; }
        public string WebRemovalBy { get; set; }
        public string CreatedBy { get; set; }
        public string PolicyStatus { get; set; }
        public string OperationalPharmacist { get; set; }
        public string PolicyTypeCollection { get; set; }
        public DateTime? ArchivalDate { get; set; }
        public bool IsArchivalApproved { get; set; }
        public string RevisionTypeName { get; set; }
        public string RevisionTypeId { get; set; }
        public bool IsReviewed { get; set; }
        public string Edit { get; set; }
        public string ClaimCodeType { get; set; }
        public string ClaimCodeValue { get; set; }
        public string UpdateHistory { get; set; }
        public DateTime? ArchivalApprovalDate { get; set; }
        public string ChronicleId { get; set; }
        public string AlternativeDetails { get; set; }
        public bool ApproveAtHcpr { get; set; }
        public Int16 RowNum { get; set; }
        public string DiagnosisDetails { get; set; }
        public string PolicyNotes { get; set; }
        public DateTime IsPublishRequestDate { get; set; }
        public string PublishRequestedBy { get; set; }

        public string ArchivalFromDateSearch { get; set; }
        public string ArchivalToDateSearch { get; set; }
        public string CurrentDate { get; set; }
        public string LimitationDetermination { get; set; }
        public int ActionType { get; set; }
        public string MessageOnly { get; set; }
        public string Operational { get; set; }

        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        
    }
}
