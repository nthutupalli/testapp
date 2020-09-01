using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Server.VaultManager;
using Common.DataTransferObjects;
using System.Data.SqlClient;
using Common.Utility;
using Common;
using System.Linq;

namespace Server.DataAccessObjects
{
    public class ClinicalPolicyDao
    {

        //string ConnectionString = VaultConfigurationManager.InstanceConnection.ConnectionString["CFConnectionString"].ToString();
        string ConnectionString = "Data Source=rx_cent_formularytest; Initial Catalog = Rx_Cent_Formulary; User ID = EPHARWEB; Password=SMKI#52M; Connect Timeout=720 ;pooling = true; Max Pool Size=200";
        public  List<ClinicalPolicySearchDto> SearchPolicies(ClinicalPolicySearchDto clinicalPolicyDto)
        {

            if (clinicalPolicyDto == null)
                throw new ArgumentNullException("clinicalPolicySearchDto");
      
        var parameters = new[]
                                        {
                                            new SqlParameter(
                                                "@PolicyName",
                                                (!string.IsNullOrEmpty(clinicalPolicyDto.PolicyName))
                                                    ? (clinicalPolicyDto.PolicyName)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@PolicyType",
                                                (!string.IsNullOrEmpty(clinicalPolicyDto.PolicyTypeCollection))
                                                    ? (clinicalPolicyDto.PolicyTypeCollection)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@TherapeuticCategoryName",
                                                (!string.IsNullOrEmpty(clinicalPolicyDto.TherapeuticCategory))
                                                    ? (clinicalPolicyDto.TherapeuticCategory)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@DrugName",
                                                (!string.IsNullOrEmpty(clinicalPolicyDto.DrugName))
                                                    ? (clinicalPolicyDto.DrugName)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@SubCategoryName",
                                                (!string.IsNullOrEmpty(clinicalPolicyDto.SubCategory))
                                                    ? (clinicalPolicyDto.SubCategory)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@LineOfBusinessName",
                                                (!string.IsNullOrEmpty(clinicalPolicyDto.LineOfBusiness))
                                                    ? (clinicalPolicyDto.LineOfBusiness)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@EffectiveStartDate",
                                                (clinicalPolicyDto.EffectiveStartDate != DateTime.MinValue)
                                                    ? (clinicalPolicyDto.EffectiveStartDate)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@EffectiveEndDate",
                                                (clinicalPolicyDto.EffectiveEndDate != DateTime.MinValue)
                                                    ? (clinicalPolicyDto.EffectiveEndDate)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@RevisionStartDate",
                                                (clinicalPolicyDto.RevisionStartDate != DateTime.MinValue)
                                                    ? (clinicalPolicyDto.RevisionStartDate)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@RevisionEndDate",
                                                (clinicalPolicyDto.RevisionEndDate != DateTime.MinValue)
                                                    ? (clinicalPolicyDto.RevisionEndDate)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@ReviewStartDate",
                                                (clinicalPolicyDto.ReviewStartDate != DateTime.MinValue)
                                                    ? (clinicalPolicyDto.ReviewStartDate)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@ReviewEndDate",
                                                (clinicalPolicyDto.ReviewEndDate != DateTime.MinValue)
                                                    ? (clinicalPolicyDto.ReviewEndDate)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@PolicyStatus",
                                                (!string.IsNullOrEmpty(clinicalPolicyDto.PolicyStatus))
                                                    ? (clinicalPolicyDto.PolicyStatus)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@Alternative",
                                                (!string.IsNullOrEmpty(clinicalPolicyDto.Alternative))
                                                    ? (clinicalPolicyDto.Alternative)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@PolicyOwnerId",
                                                (!string.IsNullOrEmpty(clinicalPolicyDto.PolicyOwner))
                                                    ? Convert.ToInt32(clinicalPolicyDto.PolicyOwner)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@LimitationDetermination",
                                                (!string.IsNullOrEmpty(clinicalPolicyDto.LimitationDetermination))
                                                    ? (clinicalPolicyDto.LimitationDetermination)
                                                    : (Object)DBNull.Value),
                                            new SqlParameter(
                                                "@PageSize",
                                                Convert.ToInt16(clinicalPolicyDto.pageSize)),
                                            new SqlParameter(
                                                "@PageIndex",
                                                Convert.ToInt16(clinicalPolicyDto.pageIndex)),
                                            new SqlParameter(
                                                "@ActionType",
                                                (clinicalPolicyDto.ActionType!=0)
                                                    ? Convert.ToInt32(clinicalPolicyDto.ActionType)
                                                    :(Object)DBNull.Value),
                                        };

            var searchResults = new DataSet();
            CustomSqlHelper.FillDataSet(
               ConnectionString, 120, "iRx_SearchClinicalPolicy", searchResults, parameters);

            var clinicalPolicySearchList = new List<ClinicalPolicySearchDto>();
            if (searchResults.Tables[0].Rows.Count > 0)
            {
                clinicalPolicySearchList.AddRange(from DataRow dr in searchResults.Tables[0].Rows
                                                  select SetClinicalPolicySearchResult(dr)
                                                 );
            }
            return clinicalPolicySearchList;
        }

        private static ClinicalPolicySearchDto SetClinicalPolicySearchResult(DataRow dataRow)
        {
            var clinicalPolicyDto = new ClinicalPolicySearchDto();
            if (dataRow.Table.Columns.Contains("PolicyName"))
            {
                clinicalPolicyDto.PolicyName = Utilities.IsNull(dataRow["PolicyName"], string.Empty).ToString();
            }
            if (dataRow.Table.Columns.Contains("PolicyType"))
            {
                clinicalPolicyDto.PolicyType = (Constants.PolicyType)Convert.ToInt16(Utilities.IsNull(dataRow["PolicyType"], 0));
            }
            if (dataRow.Table.Columns.Contains("TherapeuticCategory"))
            {
                clinicalPolicyDto.TherapeuticCategory = Utilities.IsNull(dataRow["TherapeuticCategory"], string.Empty).ToString();
            }
            if (dataRow.Table.Columns.Contains("SubCategory"))
            {
                clinicalPolicyDto.SubCategory = Utilities.IsNull(dataRow["SubCategory"], string.Empty).ToString();
            }
            if (dataRow.Table.Columns.Contains("LineOfBusiness"))
            {
                clinicalPolicyDto.LineOfBusiness = Utilities.IsNull(dataRow["LineOfBusiness"], string.Empty).ToString();
            }
            if (dataRow.Table.Columns.Contains("EffectiveDate") && dataRow["EffectiveDate"] != DBNull.Value)
            {
                clinicalPolicyDto.EffectiveStartDate = Convert.ToDateTime(dataRow["EffectiveDate"]);
            }
            if (dataRow.Table.Columns.Contains("RevisionDate") && dataRow["RevisionDate"] != DBNull.Value)
            {
                clinicalPolicyDto.RevisionStartDate = Convert.ToDateTime(dataRow["RevisionDate"]);
            }
            if (dataRow.Table.Columns.Contains("ReviewDate") && dataRow["ReviewDate"] != DBNull.Value)
            {
                clinicalPolicyDto.ReviewStartDate = Convert.ToDateTime(dataRow["ReviewDate"]);
            }
            if (dataRow.Table.Columns.Contains("PolicyOwner"))
            {
                clinicalPolicyDto.PolicyOwner = Utilities.IsNull(dataRow["PolicyOwner"], "").ToString();
            }
            if (dataRow.Table.Columns.Contains("Version"))
            {
                clinicalPolicyDto.Version = Convert.ToInt32(Utilities.IsNull(dataRow["Version"], string.Empty).ToString());//sprint2
            }
            if (dataRow.Table.Columns.Contains("Status"))
            {
                clinicalPolicyDto.Status = (Constants.PolicyStatus)Convert.ToInt16(Utilities.IsNull(dataRow["Status"], 0));
            }
            if (dataRow.Table.Columns.Contains("InternalOnly"))
            {
                clinicalPolicyDto.InternalOnly = Utilities.IsNull(dataRow["InternalOnly"], "").ToString();//sprint2
            }
            if (dataRow.Table.Columns.Contains("PolicyId"))
            {
                clinicalPolicyDto.PolicyId = Convert.ToInt32(Utilities.IsNull(dataRow["PolicyId"], string.Empty).ToString());//sprint2
            }
            if (dataRow.Table.Columns.Contains("ApprovalDate") && dataRow["ApprovalDate"] != DBNull.Value)
            {
                clinicalPolicyDto.ApprovalDate = Convert.ToDateTime(dataRow["ApprovalDate"]);
            }
            if (dataRow.Table.Columns.Contains("ConfirmDate") && dataRow["ConfirmDate"] != DBNull.Value)
            {
                clinicalPolicyDto.ConfirmDate = Convert.ToDateTime(dataRow["ConfirmDate"]);
            }
            if (dataRow.Table.Columns.Contains("RevisionId"))
            {
                clinicalPolicyDto.RevisionId = Utilities.IsNull(dataRow["RevisionId"], string.Empty).ToString();
            }
            if (dataRow.Table.Columns.Contains("IsMaximumActiveVersion"))
            {
                clinicalPolicyDto.IsMaximumActiveVersion = Convert.ToBoolean(dataRow["IsMaximumActiveVersion"]);
            }
            if (dataRow.Table.Columns.Contains("HasOtherRevisions"))
            {
                clinicalPolicyDto.HasOtherRevisions = Convert.ToBoolean(dataRow["HasOtherRevisions"]);
            }
            if (dataRow.Table.Columns.Contains("RevisionNotes"))
            {
                clinicalPolicyDto.RevisionNotes = Utilities.IsNull(dataRow["RevisionNotes"], "").ToString();
            }
            if (dataRow.Table.Columns.Contains("IsTrackChangesEnabled"))
            {
                clinicalPolicyDto.IsTrackChangesRequired = Convert.ToBoolean(dataRow["IsTrackChangesEnabled"]);
            }
            if (dataRow.Table.Columns.Contains("EffectiveEndDate") && dataRow["EffectiveEndDate"] != DBNull.Value)
            {
                clinicalPolicyDto.EffectiveEndDate = Convert.ToDateTime(dataRow["EffectiveEndDate"]);
            }
            if (dataRow.Table.Columns.Contains("CreatedBy"))
            {
                clinicalPolicyDto.CreatedBy = Utilities.IsNull(dataRow["CreatedBy"], "").ToString();
            }
            if (dataRow.Table.Columns.Contains("ArchivalDate") && dataRow["ArchivalDate"] != DBNull.Value)
            {
                clinicalPolicyDto.ArchivalDate = Convert.ToDateTime(dataRow["ArchivalDate"]);
            }
            if (dataRow.Table.Columns.Contains("IsArchivalApproved"))
            {
                clinicalPolicyDto.IsArchivalApproved = Convert.ToBoolean(dataRow["IsArchivalApproved"]);
            }
            if (dataRow.Table.Columns.Contains("RevisionTypeName"))
            {
                clinicalPolicyDto.RevisionTypeName = Utilities.IsNull(dataRow["RevisionTypeName"], string.Empty).ToString();
            }
            if (dataRow.Table.Columns.Contains("RevisionTypeId"))
            {
                clinicalPolicyDto.RevisionTypeId = Utilities.IsNull(dataRow["RevisionTypeId"], string.Empty).ToString();
            }
            if (dataRow.Table.Columns.Contains("DosageFormDesc"))
            {
                clinicalPolicyDto.DrugName = Utilities.IsNull(dataRow["DosageFormDesc"], string.Empty).ToString();
            }
            if (dataRow.Table.Columns.Contains("UpdateHistory"))
            {
                clinicalPolicyDto.UpdateHistory = Utilities.IsNull(dataRow["UpdateHistory"], string.Empty).ToString();
            }
            if (dataRow.Table.Columns.Contains("ArchivalApprovalDate") && dataRow["ArchivalApprovalDate"] != DBNull.Value)
            {
                clinicalPolicyDto.ArchivalApprovalDate = Convert.ToDateTime(dataRow["ArchivalApprovalDate"]);
            }
            if (dataRow.Table.Columns.Contains("ChronicleId"))
            {
                clinicalPolicyDto.ChronicleId = Utilities.IsNull(dataRow["ChronicleId"], string.Empty).ToString();
            }
            if (dataRow.Table.Columns.Contains("RuleStatus"))
            {
                clinicalPolicyDto.RuleStatus = (Constants.RuleStatus)Convert.ToInt16(Utilities.IsNull(dataRow["RuleStatus"], 0));
            }
            if (dataRow.Table.Columns.Contains("RulesManualArchvalDate") && dataRow["RulesManualArchvalDate"] != DBNull.Value)
            {
                clinicalPolicyDto.RulesManualArchivalDate = Convert.ToDateTime(dataRow["RulesManualArchvalDate"]);
            }
            if (dataRow.Table.Columns.Contains("IsPolicySentToTI") && dataRow["IsPolicySentToTI"] != DBNull.Value)
            {
                clinicalPolicyDto.IsPolicySentToTI = Convert.ToInt16(dataRow["IsPolicySentToTI"]);
            }
            return clinicalPolicyDto;
        }
    }
}
