using Common;
using Common.DataTransferObjects;
using Microsoft.Extensions.Configuration;
using Server.VaultManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Server.DataAccessObjects
{
    public class ClinicalPolicyAdminDao
    {

        private readonly IConfiguration _config;
        private readonly string ConnectionString = string.Empty;
        public ClinicalPolicyAdminDao(IConfiguration config)
        {
            _config = config;
            ConnectionString = new VaultConfigurationManager(_config).InstanceConnection.ConnectionString["CFConnectionString"].ToString();
        }
        public void SaveLob(Collection<PolicyLobDto> policyLobDtoCollection)
        {
            if (policyLobDtoCollection == null)
                throw new ArgumentNullException("policyLobDtoCollection");

            foreach (var policyLobDto in policyLobDtoCollection.Where(policyLobDto => policyLobDto.ActionType != Constants.ActionType.None))
            {
                var parameters = new[]
                    {
                        new SqlParameter(
                                                "@LobId",policyLobDto.LobId),
                                                 new SqlParameter(
                                                "@LobName",policyLobDto.LobName),
                                                 new SqlParameter(
                                                "@UpdatedBy",policyLobDto.UpdatedBy),
                                                 new SqlParameter(
                                                "@ActionType",policyLobDto.ActionType.ToString()),
                                                  new SqlParameter(
                                                "@IsActive",policyLobDto.IsActive)
                    };

                CustomSqlHelper.ExecuteNonQuery(ConnectionString, "iRx_SaveLobDetails", parameters);
            }
           
        }
        public FormularyMappingDto GetFormularyDetails()
        {
            var policyResults = new DataSet();
            var formularyMappingDto = new FormularyMappingDto();
            CustomSqlHelper.FillDataSet(
               ConnectionString, 120, "iRx_GetFormularyPlanYear", policyResults);

            if (policyResults.Tables.Count > 0)
            {
                foreach (DataRow dataRow in policyResults.Tables[0].Rows)
                {
                    formularyMappingDto.PlanYear.Add(Convert.ToInt32(dataRow["PlanYear"]));
                }
            }

            return formularyMappingDto;
        }
        public bool CheckIfPolicyExists(int lobId)
        {
            //var parameter = new SqlParameter("@LobId", lobId);
            //return Convert.ToBoolean(SqlHelper.ExecuteScalar(ConnectionString, "iRx_CheckIfPolicyExistsforLOB", parameter));

            SqlConnection conn = null;
            string sqlCommand = "iRx_CheckIfPolicyExistsforLOB";
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var param1 = new SqlParameter("@LobId", lobId)
                {
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(param1);

                return Convert.ToBoolean(cmd.ExecuteScalar());

            }
        }

        public Collection<ArgusCustomerDto> GetCustomers(Int16 lobId)
        {
            var masterData = new DataSet();

            var parameters = new[]
                {
                    new SqlParameter(
                        "@LobId", lobId)
                };
            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetLobMappingDetails", masterData,
                                        parameters);

            if (masterData.Tables.Count > 0)
            {
                Collection<ArgusCustomerDto> ArgusCustomer = CreateArgusCustomerDto(masterData.Tables[0]);
                return ArgusCustomer;
            }
            return null;

            
        }
        public Collection<ArgusClientDto> GetAvailableClients(Int16 lobId)
        {
            var masterData = new DataSet();

            var parameters = new[]
                {
                    new SqlParameter(
                        "@LobId", lobId)
                };
            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetLobMappingDetails", masterData,
                                        parameters);

            if (masterData.Tables.Count > 0)
            {
                Collection<ArgusClientDto> ArgusClient = CreateArgusClientDto(masterData.Tables[1]);
                return ArgusClient;
            }
            return null;


        }

        /// <summary>
        /// Create Customer Id Collection
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private  Collection<ArgusCustomerDto> CreateArgusCustomerDto(DataTable dataTable)
        {
            var argusCustomerCollection = new Collection<ArgusCustomerDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var argusCustomerDto = new ArgusCustomerDto
                    {
                        CustomerId = Convert.ToInt16(dataRow["CustomerId"]),
                        CustomerCode = Convert.ToString(dataRow["CustomerCode"]),
                        IsMapped = Convert.ToBoolean(dataRow["IsMapped"])
                    };

                    argusCustomerCollection.Add(argusCustomerDto);
                }
            }

            return argusCustomerCollection;
        }

        /// <summary>
        /// Create Client Id Collection
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private  Collection<ArgusClientDto> CreateArgusClientDto(DataTable dataTable)
        {
            var argusCustomerCollection = new Collection<ArgusClientDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var argusClientDto = new ArgusClientDto
                    {
                        ClientId = Convert.ToInt16(dataRow["ClientId"]),
                        ClientCode = Convert.ToString(dataRow["ClientCode"]),
                        CustomerId = Convert.ToInt16(dataRow["CustomerId"]),
                        IsMapped = Convert.ToBoolean(dataRow["IsMapped"])
                    };

                    argusCustomerCollection.Add(argusClientDto);
                }
            }

            return argusCustomerCollection;
        }

        /// <summary>
        ///  Get user FormId Details as per plan year
        /// </summary>
        /// <param name="policyTypeId"></param>
        public  List<FormularyDetailsDto> GetUserFormularyIdDetails(int planYear, int? lobId)
        {
            var formularyDetailList = new List<FormularyDetailsDto>();
            var policyResults = new DataSet();
            var parameters = new[]
                    {
                        new SqlParameter("@PlanYear",planYear),
                        new SqlParameter("@LobId",lobId),
                    };
            var formularyMappingDto = new FormularyMappingDto();
            CustomSqlHelper.FillDataSet(
               ConnectionString, 120, "iRx_GetUserFormularyIdDetails", policyResults, parameters);


            if (policyResults.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dataRow in policyResults.Tables[0].Rows)
                {
                    FormularyDetailsDto formularydetails = new FormularyDetailsDto();

                    if (dataRow.Table.Columns.Contains("UserFormId"))
                        formularydetails.UserFormId = dataRow["UserFormId"].ToString();

                    if (dataRow.Table.Columns.Contains("FormName"))
                        formularydetails.FormName = dataRow["FormName"].ToString();
                    formularyDetailList.Add(formularydetails);
                }
            }

            return formularyDetailList;
        }

        public  void SaveLobMappingDetails(Collection<ArgusCustomerDto> ArgusCustomerDtoCollection,Collection<ArgusClientDto> ArgusClientDtoCollection,Int16 lobId)
        {
           
            var argusCustomerCollection = ArgusCustomerDtoCollection;

            if (argusCustomerCollection != null)
            {
                foreach (var argusCustomer in argusCustomerCollection.Where(argusCustomer => argusCustomer.ActionType != Constants.ActionType.None))
                {
                    var parameters = new[]
                    {
                        new SqlParameter(
                                                "@LobId",lobId),
                                                 new SqlParameter(
                                                "@LobMappingTypeId",1),
                                                 new SqlParameter(
                                                "@LobMappingValue",argusCustomer.CustomerCode),
                                                 new SqlParameter(
                                                "@ActionType",argusCustomer.ActionType.ToString())
                    };

                    CustomSqlHelper.ExecuteNonQuery(ConnectionString, "iRx_SaveLobMapping", parameters);
                }
            }

            var argusClientCollection = ArgusClientDtoCollection;

            if (argusClientCollection != null)
            {
                foreach (var argusClient in argusClientCollection.Where(argusClient => argusClient.ActionType != Constants.ActionType.None))
                {
                    var parameters = new[]
                    {
                        new SqlParameter(
                                                "@LobId",lobId),
                                                 new SqlParameter(
                                                "@LobMappingTypeId",2),
                                                 new SqlParameter(
                                                "@LobMappingValue",argusClient.ClientCode),
                                                 new SqlParameter(
                                                "@ActionType",argusClient.ActionType.ToString())
                    };

                    CustomSqlHelper.ExecuteNonQuery(ConnectionString, "iRx_SaveLobMapping", parameters);
                }
            }

        }

        public  List<FormularyDetailsDto> GetSavedFormularyIdDetails(int planYear, int? lobId)
        {
            var formularyDetailList = new List<FormularyDetailsDto>();
            //var searchResultList = new List<FormularyDetailsDto>();
            SqlConnection conn = null;
            string sqlCommand = "iRx_GetSavedLobFormularyDetail";
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var param1 = new SqlParameter("@PlanYear", planYear)
                {
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(param1);
                var param2 = new SqlParameter("@LobId", lobId)
                {
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(param2);
                var searchResult = cmd.ExecuteReader();
                if (searchResult.HasRows)
                {
                    while (searchResult.Read())
                    {
                        //searchResultList.Add(string.Format("{0};{1};{2}", searchResult["DosageFormId"], searchResult["DosageFormDesc"], searchResult["BrandName"]));
                        FormularyDetailsDto formularydetails = new FormularyDetailsDto();
                        formularydetails.UserFormId = searchResult["UserFormId"].ToString();
                        formularydetails.FormName = searchResult["FormName"].ToString();
                        formularyDetailList.Add(formularydetails);
                    }
                }
            }
            return formularyDetailList;
        }

        public  void SaveFormularyMappingDetails(DataTable formularyMappingDto)
        {
            SqlConnection conn = null;
            string sqlCommand = "dbo.iRx_SaveFormularyMapping";
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var parm1 = new SqlParameter("@FormulayDetail", formularyMappingDto) { Direction = ParameterDirection.Input };
                parm1.SqlDbType = SqlDbType.Structured;
                parm1.TypeName = "CPS_FormularyIdDetail";
                cmd.Parameters.Add(parm1);
                cmd.ExecuteNonQuery();
            }

        }
        public void SaveLookBackPeriod(Collection<RuleLookBackPeriodDto> ruleLookBackPeriodDtoCollection)
        {
            if (ruleLookBackPeriodDtoCollection == null)
                throw new ArgumentNullException("ruleLookBackPeriodDtoCollection");

            foreach (var ruleLookbackPeriodDto in ruleLookBackPeriodDtoCollection.Where(ruleLookBackPeriodDto => ruleLookBackPeriodDto.ActionType != Constants.ActionType.None))
            {
                var parameters = new[]
                    {
                        new SqlParameter(
                                                "@LookBackId",ruleLookbackPeriodDto.LookBackId),
                                                 new SqlParameter(
                                                "@LookBackValue",ruleLookbackPeriodDto.LookBackValue),
                                                 new SqlParameter(
                                                "@LookBackUnit",ruleLookbackPeriodDto.LookBackUnit),
                                                new SqlParameter("@UpdatedBy",ruleLookbackPeriodDto.UpdatedBy),
                                                 new SqlParameter(
                                                "@ActionType",ruleLookbackPeriodDto.ActionType.ToString())
                    };

                CustomSqlHelper.ExecuteNonQuery(ConnectionString, "iRx_SaveRuleLookBackPeriodDetails", parameters);
            }
        }
        
        private static Collection<PolicyLobDto> CreatePolicyLobDto(DataTable dataTable)
        {
            var policyLobCollection = new Collection<PolicyLobDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var policyLobDto = new PolicyLobDto
                    {
                        LobId = Convert.ToInt16(dataRow["ID"]),
                        LobName = Convert.ToString(dataRow["Name"]),
                        IsActive = Convert.ToBoolean(dataRow["IsActive"]),
                        Status = Convert.ToString(dataRow["Status"]),
                    };

                    policyLobCollection.Add(policyLobDto);
                }
            }

            return policyLobCollection;
        }

        public  bool CheckPolicyOwnerPolicyMapping(Int16 policyOwnerId)
        {
            var therapeuticCategoryDataSet = new DataSet();

            var parameters = new[]
                {
                    new SqlParameter(
                        "@PolicyOwnerId", policyOwnerId)
                };

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_CheckPolicyOwnerPolicyMapping", therapeuticCategoryDataSet,
                                       parameters);

            if (therapeuticCategoryDataSet.Tables[0].Rows.Count > 0)
                return true;

            return false;
        }

        public void SavePolicyOwnerGrid(Collection<PolicyOwnerDto> policyOwnerDtoCollection)
        {
            if (policyOwnerDtoCollection == null)
                throw new ArgumentNullException("policyOwnerDtoCollection");

            foreach (var policyOwnerDto in policyOwnerDtoCollection.Where(policyOwnerDto => policyOwnerDto.ActionType != Constants.ActionType.None))
            {
                var parameters = new[]
                    {
                        new SqlParameter(
                                                "@PolicyOwnerId",policyOwnerDto.PolicyOwnerId),
                                                 new SqlParameter(
                                                "@OwnerName",policyOwnerDto.OwnerName),
                                                 new SqlParameter(
                                                "@OwnerEmail",policyOwnerDto.OwnerEmail),
                                                new SqlParameter(
                                                "@UpdatedBy",policyOwnerDto.UpdatedBy),
                                                 new SqlParameter(
                                                "@ActionType",policyOwnerDto.ActionType.ToString()),
                                                 new SqlParameter(
                                                 "@IsActive",policyOwnerDto.IsActive)
                    };

                CustomSqlHelper.ExecuteNonQuery(ConnectionString, "iRx_SavePolicyOwnerDetails", parameters);
            }
        }

        public  Collection<PolicyRejectCodeDto> GetPolicyTypeRejectCodeMapping(Int16 policyTypeId)
        {
            var policyRejectCodeCollection = new Collection<PolicyRejectCodeDto>();
            var masterData = new DataSet();

            var parameters = new[]
                {
                    new SqlParameter(
                        "@PolicyTypeId", policyTypeId)
                };
            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetRejectCodeMappingDetails", masterData,
                                        parameters);

            if (masterData.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dataRow in masterData.Tables[0].Rows)
                {
                    var policyRejectCodeDto = new PolicyRejectCodeDto
                    {
                        RejectCodeId = Convert.ToInt32(dataRow["RejectCodeId"]),
                        RejectCode = Convert.ToString(dataRow["RejectCode"]),
                        RejectCodeDesc = Convert.ToString(dataRow["RejectCodeDesc"]),
                        IsMapped = Convert.ToBoolean(dataRow["IsMapped"])
                    };

                    policyRejectCodeCollection.Add(policyRejectCodeDto);
                }
            }

            return policyRejectCodeCollection;
        }

        public  void SaveRejectCodesDetails(Collection<PolicyRejectCodeDto> rejectCodeDtoCollection)
        {
            if (rejectCodeDtoCollection == null)
                throw new ArgumentNullException("rejectCodeDtoCollection");

            foreach (var rejectCodeDto in rejectCodeDtoCollection.Where(rejectCodeDto => rejectCodeDto.ActionType != Constants.ActionType.None))
            {
                var parameters = new[]
                    {
                        new SqlParameter(
                                                "@RejectCodeId",rejectCodeDto.RejectCodeId),
                                                 new SqlParameter(
                                                "@RejectCode",rejectCodeDto.RejectCode),
                                                 new SqlParameter(
                                                "@RejectCodeDesc",rejectCodeDto.RejectCodeDesc),
                                                new SqlParameter("@UpdatedBy",rejectCodeDto.UpdatedBy),
                                                 new SqlParameter(
                                                "@ActionType",rejectCodeDto.ActionType.ToString())
                    };

                CustomSqlHelper.ExecuteNonQuery(ConnectionString, "iRx_SaveRejectCodes", parameters);
            }
        }

        
        public  void SaveMappedRejectCodeDetails(Collection<PolicyRejectCodeDto> policyRejectCodeCollection, Int16 policyTypeId)
        {
            if (policyRejectCodeCollection == null)
                throw new ArgumentNullException("policyRejectCodeCollection");

            foreach (var policyRejectCodeDto in policyRejectCodeCollection.Where(rejectCodeDto => rejectCodeDto.ActionType != Constants.ActionType.None))
            {
                var parameters = new[]
                    {
                        new SqlParameter("@PolicyTypeId",policyTypeId),
                         new SqlParameter("@RejectCodeId",policyRejectCodeDto.RejectCodeId),
                         new SqlParameter("@ActionType",policyRejectCodeDto.ActionType.ToString())
                    };

                CustomSqlHelper.ExecuteNonQuery(ConnectionString, "iRx_SaveRejectCodeMapping", parameters);
            }

        }


        public  bool CheckTherapeuticCategoryPolicyMapping(Int16 therapeuticCategoryId)
        {
            var therapeuticCategoryDataSet = new DataSet();

            var parameters = new[]
                {
                    new SqlParameter(
                        "@TherapeuticCategoryId", therapeuticCategoryId)
                };

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_CheckTherapeuticCategoryPolicyMapping", therapeuticCategoryDataSet,
                                       parameters);

            if (therapeuticCategoryDataSet.Tables[0].Rows.Count > 0)
                return true;

            return false;
        }


        public  void SaveTherapeuticCategory(Collection<TherapeuticCategoryDto> therapeuticCategoryDtoCollection)
        {
            if (therapeuticCategoryDtoCollection == null)
                throw new ArgumentNullException("therapeuticCategoryDtoCollection");

            foreach (var therapeuticCategoryDto in therapeuticCategoryDtoCollection.Where(therapeuticCategoryDto => therapeuticCategoryDto.ActionType != Constants.ActionType.None))
            {
                var parameters = new[]
                    {
                        new SqlParameter(
                                                "@TherapeuticCategoryId",therapeuticCategoryDto.TherapeuticCategoryId),
                                                 new SqlParameter(
                                                "@TherapeuticCategoryName",therapeuticCategoryDto.TherapeuticCategoryName),
                                                new SqlParameter(
                                                "@UpdatedBy",therapeuticCategoryDto.UpdatedBy),
                                                 new SqlParameter(
                                                "@ActionType",therapeuticCategoryDto.ActionType.ToString())
                    };

                CustomSqlHelper.ExecuteNonQuery(ConnectionString, "iRx_SaveTherapeuticCategoryDetails", parameters);
            }
        }

        public  bool CheckSubCategoryPolicyMapping(Int16 subCategoryId)
        {
            var therapeuticCategoryDataSet = new DataSet();

            var parameters = new[]
                {
                    new SqlParameter(
                        "@SubCategoryId", subCategoryId)
                };

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_CheckSubCategoryPolicyMapping", therapeuticCategoryDataSet,
                                       parameters);

            if (therapeuticCategoryDataSet.Tables[0].Rows.Count > 0)
                return true;

            return false;
        }

        public  void SaveSubCategory(Collection<SubCategoryDto> subCategoryDtoCollection)
        {
            if (subCategoryDtoCollection == null)
                throw new ArgumentNullException("subCategoryDtoCollection");

            foreach (var subCategoryDto in subCategoryDtoCollection.Where(subCategoryDto => subCategoryDto.ActionType != Constants.ActionType.None))
            {
                var parameters = new[]
                    {
                        new SqlParameter(
                                                "@SubCategoryId",subCategoryDto.SubCategoryId),
                                                 new SqlParameter(
                                                "@SubCategoryName",subCategoryDto.SubCategoryName),
                                                new SqlParameter(
                                                "@UpdatedBy",subCategoryDto.UpdatedBy),
                                                 new SqlParameter(
                                                "@ActionType",subCategoryDto.ActionType.ToString())
                    };

                CustomSqlHelper.ExecuteNonQuery(ConnectionString, "iRx_SaveSubCategoryDetails", parameters);
            }
        }

        public void SavePolicyTemplate(PolicyTemplateDto policyTemplateDto)
        {
            if (policyTemplateDto == null)
                throw new ArgumentNullException("policyTemplateDto");

            var parameters = new[]
                    {
                         new SqlParameter("@PolicyTypeId",Convert.ToInt16(policyTemplateDto.PolicyType)),
                         new SqlParameter("@VersionControlDisclaimer",policyTemplateDto.VersionControlDisclaimer),
                         new SqlParameter("@PolicyDisclaimer",policyTemplateDto.PolicyDisclaimer),
                         new SqlParameter("@FooterDisClaimer",policyTemplateDto.FooterDisClaimer),
                         new SqlParameter("@CdCompendium",policyTemplateDto.CdCompendium),
                         new SqlParameter("@InternalOnlyDisclaimer",policyTemplateDto.InternalOnlyDisclaimer),
                         new SqlParameter("@ExperimentalDisclaimer",policyTemplateDto.ExperimentalDisclaimer),
                         new SqlParameter("@PrescriberInstructions",policyTemplateDto.PrescriberInstructions),
                         new SqlParameter("@UpdatedBy",policyTemplateDto.UpdatedBy),
                         new SqlParameter("@ProviderClaimCodes",policyTemplateDto.ProviderClaimCodes)
                    };

            CustomSqlHelper.ExecuteNonQuery(ConnectionString, "iRx_SavePolicyTemplate", parameters);
        }

       

        public List<LookupDataDto> GetLookUpList(string functionCode)
        {
            var masterDataDictionary =
               new Dictionary<Constants.ClinicalPolicyMasterDataType, object>();
            var parameter = new[]

                            {

                                new SqlParameter("@FunctionType", functionCode)

                            };
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails_API", masterData, parameter);
            var policyTypeCollection = new List<LookupDataDto>();
            if (masterData != null && masterData.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dataRow in masterData.Tables[0].Rows)
                {

                    var policyTypeDto = new LookupDataDto
                    {
                        Id = Convert.ToInt16(dataRow["Id"]),
                        Name = Convert.ToString(dataRow["Name"]),
                        Active = Convert.ToBoolean(dataRow["IsActive"])
                    };

                    policyTypeCollection.Add(policyTypeDto);
                }
            }

            return policyTypeCollection;
        }



    }
}
