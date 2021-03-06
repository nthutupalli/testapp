/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using System;
using System.Collections.Generic;
using System.Data;
using Server.VaultManager;
using Common.DataTransferObjects;
using System.Data.SqlClient;
using Common;
using Microsoft.Extensions.Configuration;
using System.Globalization;


namespace Server.DataAccessObjects
{
    public class MasterDataDao
    {
        private readonly IConfiguration _config;
        private readonly string ConnectionString = string.Empty;
        readonly int count = 120;
        const int PosZero = 0;
        const int PosOne = 1;
        const int PosTwo = 2;
        const int PosThree = 3;
        const int PosFour = 4;
        const int PosFive = 5;
        const int PosSix = 6;
        const int PosSeven = 7;
        const int PosEight = 8;
        const int PosNine = 9;
        const int PosTen = 10;
        const int PosEleven = 11;
        const int PosTwelve = 12;
        const int PosThirteen = 13;
        const int PosFourteen = 14;
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
            masterData.Locale = CultureInfo.InvariantCulture;


           

            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);
           

            if (masterData.Tables.Count > 0)
            {
                masterDataDictionary.Add("Lob", CreatePolicyLobDto(masterData.Tables[PosZero]));
                masterDataDictionary.Add("PolicyType", CreatePolicyTypeDto(masterData.Tables[PosOne]));
                masterDataDictionary.Add("TherapeuticCategory", CreateTherapeuticCategoryCollection(masterData.Tables[PosTwo]));
                masterDataDictionary.Add("SubCategory", CreateSubCategoryCollection(masterData.Tables[PosThree]));
                masterDataDictionary.Add("PolicyOwner", CreatePolicyOwnerCollection(masterData.Tables[PosFour]));
                masterDataDictionary.Add("RuleLookBackPeriod", CreateRuleLookBackPeriodCollection(masterData.Tables[PosFive]));
                masterDataDictionary.Add("RejectCode", CreatePolicyRejectCodeCollection(masterData.Tables[PosSix]));
                masterDataDictionary.Add("Template", CreatePolicyTemplateCollection(masterData.Tables[PosSeven]));
                masterDataDictionary.Add("RuleConcept", CreateRuleConceptCollection(masterData.Tables[PosEight]));
                masterDataDictionary.Add("PolicyTypeDefault", CreatePolicyDefaultCollection(masterData.Tables[PosNine]));
                
                masterDataDictionary.Add("RevisionType", CreateRevisionTypeCollection(masterData.Tables[PosTen]));
                masterDataDictionary.Add("UpdateType", CreateUpdateTypeCollection(masterData.Tables[PosEleven]));
                masterDataDictionary.Add("CPLob", CreateCPLobDetailsDto(masterData.Tables[PosTwelve]));
                masterDataDictionary.Add("PolicyStatus", CreatePolicyStatusDetailsDto(masterData.Tables[PosThirteen]));
               masterDataDictionary.Add("PrimaryLobSubCategory", CreatePrimaryLobStatusDto(masterData.Tables[PosFourteen]));
            }

            return masterDataDictionary;
        }


        public Dictionary<string, object> LobList()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            masterData.Locale = CultureInfo.InvariantCulture;

            

            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[PosZero]);


            if (masterData.Tables.Count > 0)
            {
                masterDataDictionary.Add("Lob", CreatePolicyLobDto(masterData.Tables[PosZero]));
               
            }

            return masterDataDictionary;
        }

        

        public Dictionary<string, object> PolicyType()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();

            masterData.Locale = CultureInfo.InvariantCulture;
            

            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);
             if (masterData.Tables.Count > 0)
            {
                masterDataDictionary.Add("PolicyType", CreatePolicyTypeDto(masterData.Tables[PosOne]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> TherapeuticCategory()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
            masterData.Locale = CultureInfo.InvariantCulture;

             CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
               
                masterDataDictionary.Add("TherapeuticCategory", CreateTherapeuticCategoryCollection(masterData.Tables[PosTwo]));
                
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> SubCategory()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
            masterData.Locale = CultureInfo.InvariantCulture;

                       CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
               
                masterDataDictionary.Add("SubCategory", CreateSubCategoryCollection(masterData.Tables[PosThree]));

            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> PolicyOwner()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
            masterData.Locale = CultureInfo.InvariantCulture;

               CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);
       if (masterData.Tables.Count > 0)
            {
              
                masterDataDictionary.Add("PolicyOwner", CreatePolicyOwnerCollection(masterData.Tables[PosFour]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> RuleLookBackPeriod()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
            masterData.Locale = CultureInfo.InvariantCulture;

 
            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
              
                masterDataDictionary.Add("RuleLookBackPeriod", CreateRuleLookBackPeriodCollection(masterData.Tables[PosFive]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> RejectCode()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
            masterData.Locale = CultureInfo.InvariantCulture;


            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
                masterDataDictionary.Add("RejectCode", CreatePolicyRejectCodeCollection(masterData.Tables[PosSix]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> Template()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
           masterData.Locale = CultureInfo.InvariantCulture;


            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);
           if (masterData.Tables.Count > 0)
            {
              
                masterDataDictionary.Add("Template", CreatePolicyTemplateCollection(masterData.Tables[PosSeven]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> RuleConcept()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
        masterData.Locale = CultureInfo.InvariantCulture;

            
            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);
            if (masterData.Tables.Count > 0)
            {
              
                masterDataDictionary.Add("RuleConcept", CreateRuleConceptCollection(masterData.Tables[PosEight]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> PolicyTypeDefault()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
          masterData.Locale = CultureInfo.InvariantCulture;

            
            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
               
                masterDataDictionary.Add("PolicyTypeDefault", CreatePolicyDefaultCollection(masterData.Tables[PosNine]));
                
            }

            return masterDataDictionary;
        }


        


        

        public Dictionary<string, object> RevisionType()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
            masterData.Locale = CultureInfo.InvariantCulture;


            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
               
                masterDataDictionary.Add("RevisionType", CreateRevisionTypeCollection(masterData.Tables[PosTen]));
                
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> UpdateType()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
            masterData.Locale = CultureInfo.InvariantCulture;


            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);
            if (masterData.Tables.Count > 0)
            {
               
                masterDataDictionary.Add("UpdateType", CreateUpdateTypeCollection(masterData.Tables[PosEleven]));
               
            }

            return masterDataDictionary;
        }

        public Dictionary<string, object> CPLob()
        {
            var masterDataDictionary =
                new Dictionary<string, object>();
            var masterData = new DataSet();
            masterData.Locale = CultureInfo.InvariantCulture;

 
            CustomSqlHelper.FillDataSet(ConnectionString, count, "iRx_GetPolicyMasterDetails", masterData, new SqlParameter[0]);

            if (masterData.Tables.Count > 0)
            {
              
                masterDataDictionary.Add("CPLob", CreateCPLobDetailsDto(masterData.Tables[PosTwelve]));
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
                        LobSubCategory=dataRow["LobType"]!=DBNull.Value? !Convert.ToBoolean(dataRow["LobType"]) ? "Primary" : "Secondary":"",
                        PrimaryLobSubCategory=Convert.ToString(dataRow["PrimaryLobSubCategory"])
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

        private List<PolicyStatusDto> CreatePolicyStatusDetailsDto(DataTable dataTable)
        {
            var PolicyStatusLobCollection = new List<PolicyStatusDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var policyLobDto = new PolicyStatusDto
                    {
                        PolicyStatusId = Convert.ToInt16(dataRow["PolicyStatusId"]),
                        StatusCode = Convert.ToInt16(dataRow["StatusCode"]),
                        StatusName = Convert.ToString(dataRow["StatusName"]),
                    };

                    PolicyStatusLobCollection.Add(policyLobDto);
                }
            }

            return PolicyStatusLobCollection;
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

        /// <summary>
        /// CreateUpdateTypeCollection
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<PrimaryLobSubCategoryDto> CreatePrimaryLobStatusDto(DataTable dataTable)
        {
            var primaryLobSubCategoryDto = new List<PrimaryLobSubCategoryDto>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var primaryLobSubCatDto = new PrimaryLobSubCategoryDto
                    {
                        PrimaryLobId = Convert.ToInt16(dataRow["PrimaryLobId"]),
                        PrimaryLobName = Convert.ToString(dataRow["PrimaryLobName"]),
                    };

                    primaryLobSubCategoryDto.Add(primaryLobSubCatDto);
                }
            }

            return primaryLobSubCategoryDto;
        }
    }
}
