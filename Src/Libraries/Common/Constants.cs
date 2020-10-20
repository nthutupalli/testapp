using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Common
{
    public class Constants
    {

        public class ErrorMessage
        {
            /// <summary>
            ///Enterprise Logging Error Message
            /// </summary>
            public static string ErrorCode = "Service - Error while connecting to the server";
            public const string LogEventTypeError = "ERROR";
            public const string LogSeverityLow = "LOW";
        }
        public class Message
        {
            /// <summary>
            ///Enterprise Logging Error Message
            /// </summary>
            public static string Success = "Success";
            public static string Failed = "failed";
            public static string BadRequest = "BadRequest";
            public static string IdsValues = "Id should contain a positive value.";


        }
        /// PolicyType
        /// </summary>
        [DataContract]
        public enum PolicyType
        {
            /// <summary>
            /// None
            /// </summary>
            [Description("None")]
            [EnumMember(Value = "0")]
            None = 0,

            /// <summary>
            /// Guidance
            /// </summary>
            [Description("Guidance")]
            [EnumMember(Value = "1")]
            Guidance = 1,

            /// <summary>
            /// PriorAuthorization
            /// </summary>
            [Description("Prior Authorization")]
            [EnumMember(Value = "2")]
            PriorAuthorization = 2,

            /// <summary>
            /// StepTherapy
            /// </summary>
            [Description("Step Therapy")]
            [EnumMember(Value = "3")]
            StepTherapy = 3,

            /// <summary>
            /// NonFormulary
            /// </summary>
            [Description("Non Formulary")]
            [EnumMember(Value = "4")]
            NonFormulary = 4,

            /// <summary>
            /// QuantityLimit
            /// </summary>
            [Description("Quantity Limit")]
            [EnumMember(Value = "5")]
            QuantityLimit = 5,

            /// <summary>
            /// Medical Prior Authorization
            /// </summary>
            [Description("Medical Prior Authorization")]
            [EnumMember(Value = "6")]
            MedicalPriorAuthorization = 6,

            /// <summary>
            /// MYB
            /// </summary>
            [Description("MYB")]
            [EnumMember(Value = "7")]
            MYB = 7
        }

        /// <summary>
        /// Policy Status Types
        /// </summary>
        [DataContract]
        public enum PolicyStatus
        {
            /// <summary>
            /// None
            /// </summary>
            [Description("None")]
            [EnumMember(Value = "0")]
            None = 0,
            /// <summary>
            /// Approved
            /// </summary>
            [Description("Approved")]
            [EnumMember(Value = "1")]
            Approved = 1,
            /// <summary>
            /// Weekly Approved With Revisions
            /// </summary>
            [Description("Approved With Revisions")]
            [EnumMember(Value = "2")]
            WeeklyApprovedWithRevisions = 2,
            /// <summary>
            /// Archived
            /// </summary>
            [Description("Archived")]
            [EnumMember(Value = "3")]
            Archived = 3,
            /// <summary>
            /// Monthly Approved With Revisions
            /// </summary>
            [Description("Approved With Revisions")]
            [EnumMember(Value = "5")]
            MonthlyApprovedWithRevisions = 5,
            /// <summary>
            /// Draft
            /// </summary>
            [Description("Draft")]
            [EnumMember(Value = "6")]
            Draft = 6,
            /// <summary>
            /// Pending Approval
            /// </summary>
            [Description("Pending Approval")]
            [EnumMember(Value = "7")]
            PendingApproval = 7,
            /// <summary>
            /// Pending Archival
            /// </summary>
            [Description("Pending Archival")]
            [EnumMember(Value = "8")]
            PendingArchival = 8,
            /// <summary>
            /// Rejected
            /// </summary>
            [Description("Rejected")]
            [EnumMember(Value = "9")]
            Rejected = 9,
            /// <summary>
            /// Inactive
            /// </summary>
            [Description("Inactive")]
            [EnumMember(Value = "10")]
            Inactive = 10,
            /// <summary>
            /// Active
            /// </summary>
            [Description("Active")]
            [EnumMember(Value = "11")]
            Active = 11,
        }

        public enum RuleStatus
        {
            /// <summary>
            /// None
            /// </summary>
            [EnumMember(Value = "0")]
            None = 0,
            /// <summary>
            /// Draft
            /// </summary>
            [EnumMember(Value = "1")]
            Draft = 1,
            /// <summary>
            /// Completed
            /// </summary>
            [EnumMember(Value = "2")]
            Completed = 2,
            /// <summary>
            /// Deployed
            /// </summary>
            [EnumMember(Value = "3")]
            Deployed = 3,
            /// <summary>
            /// RulesManuallyArchived
            /// </summary>
            [EnumMember(Value = "4")]
            RulesManuallyArchived = 4
        }
        /// <summary>
        /// ActionType
        /// </summary>
        public enum ActionType
        {
            /// <summary>
            /// None
            /// </summary>
            None,
            /// <summary>
            /// Insert
            /// </summary>
            I,
            /// <summary>
            /// Update
            /// </summary>
            U,
            /// <summary>
            /// Delete
            /// </summary>
            D
        }

        /// <summary>
        /// Clinical Policy Master Data Type
        /// </summary>
        public enum ClinicalPolicyMasterDataType
        {
            /// <summary>
            /// None
            /// </summary>
            None,
            /// <summary>
            /// LOB
            /// </summary>
            Lob,
            /// <summary>
            /// Policy Type
            /// </summary>
            PolicyType,
            /// <summary>
            /// Argus Customer
            /// </summary>
            ArgusCustomer,
            /// <summary>
            /// Argus Client
            /// </summary>
            ArgusClient,
            /// <summary>
            /// Policy Owner
            /// </summary>
            PolicyOwner,
            /// <summary>
            /// Therapeutic Category
            /// </summary>
            TherapeuticCategory,
            /// <summary>
            /// SubCategory
            /// </summary>
            SubCategory,
            /// <summary>
            /// RuleLookBackPeriod
            /// </summary>
            RuleLookBackPeriod,
            /// <summary>
            /// RejectCode
            /// </summary>
            RejectCode,
            /// <summary>
            /// Template
            /// </summary>
            Template,
            /// <summary>
            /// RuleConcept
            /// </summary>
            RuleConcept,
            /// <summary>
            /// PolicyTypeDefault
            /// </summary>
            PolicyTypeDefault,
            /// <summary>
            /// ClaimCodeType
            /// </summary>
            ClaimCodeType,
            /// <summary>
            /// Policy Revision Type
            /// </summary>
            RevisionType,
            /// <summary>
            /// Update Type
            /// </summary>
            UpdateType,
            /// <summary>
            /// CP Lob
            /// </summary>
            CPLob

        }


        public enum ScenarioType
        {
            /// <summary>
            /// None
            /// </summary>
            None = 0,
            /// <summary>
            /// CoverageDetermination
            /// </summary>
            CoverageDetermination = 1,
            /// <summary>
            /// CoverageLimitation
            /// </summary>
            CoverageLimitation = 2,
        }


    }
}
