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
using Microsoft.Extensions.Configuration;

namespace Server.DataAccessObjects
{
    public class MasterDataDao
    {
        private readonly IConfiguration _config;
        private readonly string ConnectionString = string.Empty;
        public MasterDataDao(IConfiguration config)
        {
            _config = config;
            ConnectionString = new VaultConfigurationManager(_config).InstanceConnection.ConnectionString["CFConnectionString"].ToString();
        }

        /// <summary>
        /// Get Master Data For Policy
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetPolicyMasterData()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
                masterDataDictionary.Add("Lob", CreatePolicyLobDto(masterData.Tables[0]));
                masterDataDictionary.Add("PolicyType", CreatePolicyTypeDto(masterData.Tables[1]));
                masterDataDictionary.Add("TherapeuticCategory", CreateTherapeuticCategoryCollection(masterData.Tables[2]));
                masterDataDictionary.Add("SubCategory", CreateSubCategoryCollection(masterData.Tables[3]));
                masterDataDictionary.Add("PolicyOwner", CreatePolicyOwnerCollection(masterData.Tables[4]));
                masterDataDictionary.Add("RuleLookBackPeriod", CreateRuleLookBackPeriodCollection(masterData.Tables[5]));
                masterDataDictionary.Add("RejectCode", CreatePolicyRejectCodeCollection(masterData.Tables[6]));
                masterDataDictionary.Add("Template", CreatePolicyTemplateCollection(masterData.Tables[7]));
                masterDataDictionary.Add("RuleConcept", CreateRuleConceptCollection(masterData.Tables[8]));
                masterDataDictionary.Add("PolicyTypeDefault", CreatePolicyDefaultCollection(masterData.Tables[9]));
                //masterDataDictionary.Add("ClaimCodeType", CreateClaimCodeTypeCollection(masterData.Tables[10]));
                masterDataDictionary.Add("RevisionType", CreateRevisionTypeCollection(masterData.Tables[10]));
                masterDataDictionary.Add("UpdateType", CreateUpdateTypeCollection(masterData.Tables[11]));
                masterDataDictionary.Add("CPLob", CreateCPLobDetailsDto(masterData.Tables[12]));
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> LobList()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
                masterDataDictionary.Add("Lob", CreatePolicyLobDto(masterData.Tables[0]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> PolicyType()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
                masterDataDictionary.Add("PolicyType", CreatePolicyTypeDto(masterData.Tables[1]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> TherapeuticCategory()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
               
                masterDataDictionary.Add("TherapeuticCategory", CreateTherapeuticCategoryCollection(masterData.Tables[2]));
                
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> SubCategory()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
               
                masterDataDictionary.Add("SubCategory", CreateSubCategoryCollection(masterData.Tables[3]));

            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> PolicyOwner()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
              
                masterDataDictionary.Add("PolicyOwner", CreatePolicyOwnerCollection(masterData.Tables[4]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> RuleLookBackPeriod()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
              
                masterDataDictionary.Add("RuleLookBackPeriod", CreateRuleLookBackPeriodCollection(masterData.Tables[5]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> RejectCode()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
                masterDataDictionary.Add("RejectCode", CreatePolicyRejectCodeCollection(masterData.Tables[6]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> Template()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
              
                masterDataDictionary.Add("Template", CreatePolicyTemplateCollection(masterData.Tables[7]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> RuleConcept()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
              
                masterDataDictionary.Add("RuleConcept", CreateRuleConceptCollection(masterData.Tables[8]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> PolicyTypeDefault()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
               
                masterDataDictionary.Add("PolicyTypeDefault", CreatePolicyDefaultCollection(masterData.Tables[9]));
                
            }

            return masterDataDictionary;
        }


        //public Dictionary<string, object> ClaimCodeType()
        //{
        //    var masterDataDictionary =
        //        new Dictionary<string, object>();
        //    var masterData = new DataSet();

        //    CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

        //    if (masterData.Tables.Count > 0)
        //    {
        //        masterDataDictionary.Add("ClaimCodeType", CreateClaimCodeTypeCollection(masterData.Tables[10]));
               
        //    }

        //    return masterDataDictionary;
        //}

        public Dictionary<string, object> RevisionType()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
               
                masterDataDictionary.Add("RevisionType", CreateRevisionTypeCollection(masterData.Tables[10]));
                
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> UpdateType()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
               
                masterDataDictionary.Add("UpdateType", CreateUpdateTypeCollection(masterData.Tables[11]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> CPLob()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            CustomSqlHelper.FillDataSet(ConnectionString, 120, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
              
                masterDataDictionary.Add("CPLob", CreateCPLobDetailsDto(masterData.Tables[12]));
            }

            return masterDataDictionary;
        }




        /// <summary>
        /// Policy LOB
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<PolicyLobDto> CreatePolicyLobDto(DataTable dataTable)
        {
            var policyLobCollection = new List<PolicyLobDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var policyLobDto = new PolicyLobDto
                    {
                        LobId = Convert.ToInt16(dataRow["LobId"]),
                        LobName = Convert.ToString(dataRow["LobName"]),
                        IsActive = Convert.ToBoolean(dataRow["IsActive"]),
                        Status = Convert.ToString(dataRow["Status"]),
                    };

                    policyLobCollection.Add(policyLobDto);
                }
            }

            return policyLobCollection;
        }

        /// <summary>
        /// CP Policy LOB Details
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<CPLobDetail> CreateCPLobDetailsDto(DataTable dataTable)
        {
            var cpPolicyDetailsLobCollection = new List<CPLobDetail>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var policyLobDto = new CPLobDetail
                    {
                        LobCode = Convert.ToInt16(dataRow["LobCode"]),
                        LobName = Convert.ToString(dataRow["LobName"]),
                        IsActive = Convert.ToInt16(dataRow["IsActive"]),
                    };

                    cpPolicyDetailsLobCollection.Add(policyLobDto);
                }
            }

            return cpPolicyDetailsLobCollection;
        }

        /// <summary>
        /// PolicyType
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<PolicyTypeDto> CreatePolicyTypeDto(DataTable dataTable)
        {

            var policyTypeCollection = new List<PolicyTypeDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var policyTypeDto = new PolicyTypeDto
                    {
                        PolicyTypeId = Convert.ToInt16(dataRow["PolicyTypeId"]),
                        PolicyTypeName = Convert.ToString(dataRow["PolicyTypeName"])
                    };

                    policyTypeCollection.Add(policyTypeDto);
                }
            }

            return policyTypeCollection;
        }

        /// <summary>
        /// Policy owner
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<PolicyOwnerDto> CreatePolicyOwnerCollection(DataTable dataTable)
        {
            var policyOwnerCollection = new List<PolicyOwnerDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var argusCustomerDto = new PolicyOwnerDto
                    {
                        PolicyOwnerId = Convert.ToInt16(dataRow["OwnerId"]),
                        OwnerName = Convert.ToString(dataRow["OwnerName"]),
                        OwnerEmail = Convert.ToString(dataRow["OwnerEmail"]),
                        IsActive = Convert.ToBoolean(dataRow["IsActive"]),
                        Status = Convert.ToString(dataRow["Status"]),
                    };

                    policyOwnerCollection.Add(argusCustomerDto);
                }
            }

            return policyOwnerCollection;
        }

        /// <summary>
        /// TherapeuticCategory
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<TherapeuticCategoryDto> CreateTherapeuticCategoryCollection(DataTable dataTable)
        {
            var therapeuticCategoryCollection = new List<TherapeuticCategoryDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var therapeuticCategoryDto = new TherapeuticCategoryDto
                    {
                        TherapeuticCategoryId = Convert.ToInt16(dataRow["TherapeuticCategoryId"]),
                        TherapeuticCategoryName = Convert.ToString(dataRow["TherapeuticCategoryName"])
                    };

                    therapeuticCategoryCollection.Add(therapeuticCategoryDto);
                }
            }

            return therapeuticCategoryCollection;
        }

        /// <summary>
        /// SubCategory
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<SubCategoryDto> CreateSubCategoryCollection(DataTable dataTable)
        {
            var subCategoryCollection = new List<SubCategoryDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var subCategoryDto = new SubCategoryDto
                    {
                        SubCategoryId = Convert.ToInt16(dataRow["SubCategoryId"]),
                        SubCategoryName = Convert.ToString(dataRow["SubCategoryName"])
                    };

                    subCategoryCollection.Add(subCategoryDto);
                }
            }

            return subCategoryCollection;
        }

        /// <summary>
        /// Rule LookBackPeriod
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<RuleLookBackPeriodDto> CreateRuleLookBackPeriodCollection(DataTable dataTable)
        {
            var ruleLookBackPeriodCollection = new List<RuleLookBackPeriodDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var subCategoryDto = new RuleLookBackPeriodDto
                    {
                        LookBackId = Convert.ToInt16(dataRow["LookBackId"]),
                        LookBackValue = Convert.ToString(dataRow["LookBackValue"]),
                        LookBackUnit = Convert.ToString(dataRow["LookBackUnit"]),
                        LookBackValueUnit = Convert.ToString(dataRow["LookBackValueUnit"]),
                        IsEditable = Convert.ToBoolean(dataRow["IsEditable"])
                    };

                    ruleLookBackPeriodCollection.Add(subCategoryDto);
                }
            }

            return ruleLookBackPeriodCollection;
        }

        /// <summary>
        /// Policy reject Codes
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<PolicyRejectCodeDto> CreatePolicyRejectCodeCollection(DataTable dataTable)
        {
            var policyRejectCodeCollection = new List<PolicyRejectCodeDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var policyRejectCodeDto = new PolicyRejectCodeDto
                    {
                        RejectCodeId = Convert.ToInt32(dataRow["RejectCodeId"]),
                        RejectCode = Convert.ToString(dataRow["RejectCode"]),
                        RejectCodeDesc = Convert.ToString(dataRow["RejectCodeDesc"])
                    };

                    policyRejectCodeCollection.Add(policyRejectCodeDto);
                }
            }

            return policyRejectCodeCollection;
        }

        /// <summary>
        /// Policy Template
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<PolicyTemplateDto> CreatePolicyTemplateCollection(DataTable dataTable)
        {
            var policyTemplateCollection = new List<PolicyTemplateDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var policyTemplateDto = new PolicyTemplateDto
                    {
                        TemplateId = Convert.ToInt16(dataRow["TemplateId"]),
                        PolicyType = (Constants.PolicyType)Convert.ToInt32(dataRow["PolicyTypeId"]),
                        VersionControlDisclaimer = Convert.ToString(dataRow["VersionControlDisclaimer"]),
                        PolicyDisclaimer = Convert.ToString(dataRow["PolicyDisclaimer"]),
                        FooterDisClaimer = Convert.ToString(dataRow["FooterDisClaimer"]),
                        CdCompendium = Convert.ToString(dataRow["CDCompendium"]),
                        InternalOnlyDisclaimer = Convert.ToString(dataRow["InternalOnlyDisclaimer"]),
                        ExperimentalDisclaimer = Convert.ToString(dataRow["ExperimentalDisclaimer"]),
                        PrescriberInstructions = Convert.ToString(dataRow["PrescriberInstructions"]),
                        ProviderClaimCodes= Convert.ToString(dataRow["ProviderClaimCodes"])
                    };

                    policyTemplateCollection.Add(policyTemplateDto);
                }
            }

            return policyTemplateCollection;
        }

        /// <summary>
        /// Rule Concept
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<RuleConceptDto> CreateRuleConceptCollection(DataTable dataTable)
        {
            var ruleConceptCollection = new List<RuleConceptDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var ruleConceptDto = new RuleConceptDto
                    {
                        ConceptId = Convert.ToInt16(dataRow["ConceptId"]),
                        ConceptName = Convert.ToString(dataRow["ConceptName"]),
                        ConceptType = Convert.ToString(dataRow["ConceptType"]),
                        DateType = Convert.ToString(dataRow["DateType"]),
                        AnchorDate = Convert.ToString(dataRow["AnchorDate"])
                    };

                    ruleConceptCollection.Add(ruleConceptDto);
                }
            }
            ruleConceptCollection.RemoveAt(ruleConceptCollection.Count - 1);
            ruleConceptCollection.RemoveAt(ruleConceptCollection.Count - 1);
            return ruleConceptCollection;
        }

        /// <summary>
        /// Revamp Rule Concept
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<RuleConceptDto> CreateRevampRuleConceptCollection(DataTable dataTable)
        {
            var ruleConceptCollection = new List<RuleConceptDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var ruleConceptDto = new RuleConceptDto
                    {
                        ConceptId = Convert.ToInt16(dataRow["ConceptId"]),
                        ConceptName = Convert.ToString(dataRow["ConceptName"]),
                        ConceptType = Convert.ToString(dataRow["ConceptType"]),
                        DateType = Convert.ToString(dataRow["DateType"]),
                        AnchorDate = Convert.ToString(dataRow["AnchorDate"])
                    };

                    ruleConceptCollection.Add(ruleConceptDto);
                }
            }
            //ruleConceptCollection.RemoveAt(ruleConceptCollection.Count - 1);
            //ruleConceptCollection.RemoveAt(ruleConceptCollection.Count - 1);
            return ruleConceptCollection;
        }

        /// <summary>
        /// Policy Type Default
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<PolicyTypeDefaultDto> CreatePolicyDefaultCollection(DataTable dataTable)
        {
            var policyDefaultCollection = new List<PolicyTypeDefaultDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var policyTypeDefaultDto = new PolicyTypeDefaultDto
                    {
                        PolicyType = (Constants.PolicyType)Convert.ToInt32(dataRow["PolicyTypeId"]),
                        ScenarioType = (Constants.ScenarioType)Convert.ToInt32(dataRow["ControlId"]),
                        DefaultText = Convert.ToString(dataRow["DefaultText"]),
                    };

                    policyDefaultCollection.Add(policyTypeDefaultDto);
                }
            }

            return policyDefaultCollection;
        }

        /// <summary>
        /// Create Claim Code Type Collection
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        //private List<PolicyClaimCodeDto> CreateClaimCodeTypeCollection(DataTable dataTable)
        //{
        //    var claimCodeTypeCollection = new List<PolicyClaimCodeDto>();
        //    if (dataTable != null && dataTable.Rows.Count > 0)
        //    {
        //        foreach (DataRow dataRow in dataTable.Rows)
        //        {
        //            var claimCodeDto = new PolicyClaimCodeDto
        //            {
        //                ClaimCodeId = Convert.ToInt32(dataRow["CodeTypeId"]),
        //                ClaimCodeType = Convert.ToString(dataRow["CodeType"]),
        //            };

        //            claimCodeTypeCollection.Add(claimCodeDto);
        //        }
        //    }

        //    return claimCodeTypeCollection;
        //}

        private List<RevisionTypeDto> CreateRevisionTypeCollection(DataTable dataTable)
        {
            var revisionTypeCollection = new List<RevisionTypeDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                int RevisionTypeIdCount = 0;
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (RevisionTypeIdCount < Convert.ToInt32(dataTable.Rows.Count) - 1)
                    {
                        var revisionTypeDto = new RevisionTypeDto
                        {
                            RevisionTypeId = Convert.ToInt16(dataRow["RevisionTypeId"]),
                            RevisionTypeName = Convert.ToString(dataRow["RevisionTypeName"]),
                        };

                        revisionTypeCollection.Add(revisionTypeDto);
                        RevisionTypeIdCount++;
                    }
                }
            }
            return revisionTypeCollection;
        }

        /// <summary>
        /// CreateUpdateTypeCollection
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<UpdateTypeDto> CreateUpdateTypeCollection(DataTable dataTable)
        {
            var updateTypeCollection = new List<UpdateTypeDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var updateTypeDto = new UpdateTypeDto
                    {
                        UpdateTypeId = Convert.ToInt16(dataRow["UpdateTypeId"]),
                        UpdateTypeName = Convert.ToString(dataRow["UpdateTypeName"]),
                    };

                    updateTypeCollection.Add(updateTypeDto);
                }
            }

            return updateTypeCollection;
        }
    }
}
