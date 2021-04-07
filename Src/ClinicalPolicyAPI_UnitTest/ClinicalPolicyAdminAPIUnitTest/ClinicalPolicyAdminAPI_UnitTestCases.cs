using ClinicalPolicyAdminAPI.Controllers;
using Common;
using Common.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace ClinicalPolicyAdminAPIUnitTest
{
    public class ClinicalPolicyAdminAPI_UnitTestCases
    {
        private AdminController Controller;
        private UtilityController UTController;
        [SetUp]
        public void Setup()
        {
            IConfiguration Configuration;
            var configurationBuilder = new ConfigurationBuilder() .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();
            Configuration = configurationBuilder.Build();
            Controller = new AdminController(Configuration);
            UTController = new UtilityController(Configuration);

        }


        [Test]
        public void SuccessForCheckLobMapping()
        {
            CompositeObject.LobValue comp = new CompositeObject.LobValue();
            comp.lobId = 3;
            var logResponse = Controller.CheckLobMapping(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");

        }
        [Test]
        public void InvalidLobID_CheckLobMapping()
        {
            CompositeObject.LobValue comp = new CompositeObject.LobValue();
            comp.lobId = -3;
            var logResponse = Controller.CheckLobMapping(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }

        [Test]
        public void SuccessForCheckPolicyOwnerMappping()
        {
            CompositeObject.PoliyOwnerIdValue comp = new CompositeObject.PoliyOwnerIdValue();
            comp.PoliyOwnerId = 3;
            var logResponse = Controller.ActivateDeactivatePolicyOwner(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");

        }
        [Test]
        public void InvalidPolicyOwnerID_CheckPolicyOwnerMappping()
        {
            CompositeObject.PoliyOwnerIdValue comp = new CompositeObject.PoliyOwnerIdValue();
            comp.PoliyOwnerId = 0;
            var logResponse = Controller.ActivateDeactivatePolicyOwner(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }


        [Test]
        public void SuccessForCheckTherapeuticCategoryMapping()
        {
            CompositeObject.therapeuticCategoryIdIdValue comp = new CompositeObject.therapeuticCategoryIdIdValue();
            comp.therapeuticCategoryId = 3;
            var logResponse = Controller.CheckTherapeuticCategoryMapping(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");

        }
        [Test]
        public void InvalidtherapeuticCategoryID_CheckTherapeuticCategoryMapping()
        {
            CompositeObject.therapeuticCategoryIdIdValue comp = new CompositeObject.therapeuticCategoryIdIdValue();
            comp.therapeuticCategoryId = -3;
            var logResponse = Controller.CheckTherapeuticCategoryMapping(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }

        [Test]
        public void SuccessForCheckSubCategoryMapping()
        {
            CompositeObject.subCategoryIdValue comp = new CompositeObject.subCategoryIdValue();
            comp.subCategoryId = 3;
            var logResponse = Controller.CheckSubCategoryMapping(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");

        }

        [Test]
        public void InvalidsubCategoryID_CheckSubCategoryMapping()
        {
            CompositeObject.subCategoryIdValue comp = new CompositeObject.subCategoryIdValue();
            comp.subCategoryId = -3;
            var logResponse = Controller.CheckSubCategoryMapping(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }
        //[Test]
        //public void SuccessForCustomers()
        //{
        //    Int16 lobId = 4;
        //    var logResponse = Success_ServiceCallCustomers(lobId);
        //    if (logResponse.IsSuccessStatusCode)
        //    {
        //        var final = logResponse.Content.ReadAsStringAsync().Result;
        //        Collection<ArgusCustomerDto> result = JsonConvert.DeserializeObject<Collection<ArgusCustomerDto>>(final);
        //        Collection<ArgusCustomerDto> comparevalue = new Collection<ArgusCustomerDto>();
        //        ArgusCustomerDto customer1 = new ArgusCustomerDto();
        //        customer1.CustomerId = 1;
        //        customer1.CustomerCode = "0319";
        //        customer1.IsMapped = false;
        //        customer1.ActionType = 0;
        //        comparevalue.Add(customer1);

        //        ArgusCustomerDto customer2 = new ArgusCustomerDto();
        //        customer2.CustomerId = 2;
        //        customer2.CustomerCode = "0320";
        //        customer2.IsMapped = false;
        //        customer2.ActionType = 0;
        //        comparevalue.Add(customer2);

        //        ArgusCustomerDto customer3 = new ArgusCustomerDto();
        //        customer3.CustomerId = 3;
        //        customer3.CustomerCode = "0544";
        //        customer3.IsMapped = false;
        //        customer3.ActionType = 0;
        //        comparevalue.Add(customer3);
        //        Assert.IsNotNull(logResponse);
        //        string json=JsonConvert.SerializeObject(comparevalue);
        //        Assert.AreEqual(result, comparevalue);
        //    }
        //}
        [Test]
        public void InvalidLobID_Customers()
        {
            CompositeObject.LobValue comp = new CompositeObject.LobValue();
            comp.lobId = -4;
            var logResponse = Controller.GetCustomers(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");
        }


        [Test]
        public void SuccessForSaveLobDetails()
        {
            Collection<PolicyLobDto> parmeter = new Collection<PolicyLobDto>();
            PolicyLobDto lob1 = new PolicyLobDto();
            lob1.LobId = 61;
            lob1.LobName = "UnitTestCaseLob";
            lob1.UpdatedBy = "SIT4034";
            lob1.LobCode = 56;
            lob1.ActionType = Constants.ActionType.None;
            lob1.LineOfBusinessIdName = "UnitTestLob_1";
            lob1.IsActive = true;
            lob1.Status = null;
            parmeter.Add(lob1);

            PolicyLobDto lob2 = new PolicyLobDto();
            lob2.LobId = 56;
            lob2.LobName = "Pucto_Updated";
            lob2.UpdatedBy = "SIT4034";
            lob1.LobCode = 50;
            lob2.ActionType = Constants.ActionType.None;
            lob2.LineOfBusinessIdName = "UnitTestLob_2";
            lob2.IsActive = false;
            lob2.Status = null;
            parmeter.Add(lob2);
            var logResponse = Controller.SaveLobDetails(parmeter) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        [Test]
        public void MissingLobName_SaveLobDetails()
        {
            Collection<PolicyLobDto> parmeter = new Collection<PolicyLobDto>();
            PolicyLobDto lob1 = new PolicyLobDto();
            lob1.LobId = 61;
            lob1.UpdatedBy = "SIT4034";
            lob1.LobCode = 56;
            lob1.ActionType = Constants.ActionType.I;
            lob1.LineOfBusinessIdName = "UnitTestLob_1";
            lob1.IsActive = true;
            lob1.Status = null;
            parmeter.Add(lob1);

            PolicyLobDto lob2 = new PolicyLobDto();
            lob2.LobId = 56;
            lob2.LobName = "Pucto_Updated";
            lob2.UpdatedBy = "SIT4034";
            lob1.LobCode = 50;
            lob2.ActionType = Constants.ActionType.U;
            lob2.LineOfBusinessIdName = "UnitTestLob_2";
            lob2.IsActive = false;
            lob2.Status = null;
            parmeter.Add(lob2);
            var logResponse = Controller.SaveLobDetails(parmeter) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }

        [Test]
        public void SuccessForSaveCustomerClientMapping()
        {
            CompositeObject.SaveCustomerClientMapping composite= new CompositeObject.SaveCustomerClientMapping();
            Collection<ArgusCustomerDto> CustomerData= new Collection<ArgusCustomerDto>();
            ArgusCustomerDto customer1 = new ArgusCustomerDto();
            customer1.CustomerId = 1;
            customer1.CustomerCode = "0319";
            customer1.IsMapped = false;
            customer1.ActionType = Constants.ActionType.None;
            CustomerData.Add(customer1);
            Collection<ArgusClientDto> ClientData = new Collection<ArgusClientDto>();
            ArgusClientDto clientData1 = new ArgusClientDto();
            clientData1.ClientId = 4;
            clientData1.ClientCode = "00005";
            clientData1.CustomerId = 1;
            clientData1.IsMapped = false;
            clientData1.ActionType = Constants.ActionType.None;
            ClientData.Add(clientData1);

            ArgusClientDto clientData2 = new ArgusClientDto();
            clientData2.ClientId = 18;
            clientData2.ClientCode = "00004";
            clientData2.CustomerId = 2;
            clientData2.IsMapped = true;
            clientData2.ActionType = Constants.ActionType.None;
            ClientData.Add(clientData2);

            composite.ArgusCustomerDtoCollection = CustomerData;
            composite.ArgusClientDtoCollection = ClientData;
            composite.lobId = 5;
            var logResponse = Controller.SaveCustomerClientMapping(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");

        }

        [Test]
        public void CustomerCollectionNULL_SaveCustomerClientMapping()
        {
            CompositeObject.SaveCustomerClientMapping composite = new CompositeObject.SaveCustomerClientMapping();

            Collection<ArgusClientDto> ClientData = new Collection<ArgusClientDto>();
            ArgusClientDto clientData1 = new ArgusClientDto();
            clientData1.ClientId = 4;
            clientData1.ClientCode = "00005";
            clientData1.CustomerId = 1;
            clientData1.IsMapped = false;
            clientData1.ActionType = Constants.ActionType.D;
            ClientData.Add(clientData1);

            ArgusClientDto clientData2 = new ArgusClientDto();
            clientData2.ClientId = 18;
            clientData2.ClientCode = "00004";
            clientData2.CustomerId = 2;
            clientData2.IsMapped = true;
            clientData2.ActionType = Constants.ActionType.I;
            ClientData.Add(clientData2);


            composite.ArgusClientDtoCollection = ClientData;
            composite.lobId = 5;
            var logResponse = Controller.SaveCustomerClientMapping(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");
        }

        [Test]
        public void InvalidLobID_SaveCustomerClientMapping()
        {
            CompositeObject.SaveCustomerClientMapping composite = new CompositeObject.SaveCustomerClientMapping();

            Collection<ArgusClientDto> ClientData = new Collection<ArgusClientDto>();
            ArgusClientDto clientData1 = new ArgusClientDto();
            clientData1.ClientId = 4;
            clientData1.ClientCode = "00005";
            clientData1.CustomerId = 1;
            clientData1.IsMapped = false;
            clientData1.ActionType = Constants.ActionType.D;
            ClientData.Add(clientData1);

            ArgusClientDto clientData2 = new ArgusClientDto();
            clientData2.ClientId = 18;
            clientData2.ClientCode = "00004";
            clientData2.CustomerId = 2;
            clientData2.IsMapped = true;
            clientData2.ActionType = Constants.ActionType.I;
            ClientData.Add(clientData2);


            composite.ArgusClientDtoCollection = ClientData;
            composite.lobId = -5;
            var logResponse = Controller.SaveCustomerClientMapping(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");
        }

        [Test]
        public void MissingClientCode_SaveCustomerClientMapping()
        {
            CompositeObject.SaveCustomerClientMapping composite = new CompositeObject.SaveCustomerClientMapping();
            Collection<ArgusCustomerDto> CustomerData = new Collection<ArgusCustomerDto>();
            ArgusCustomerDto customer1 = new ArgusCustomerDto();
            customer1.CustomerId = 1;
            customer1.CustomerCode = "0319";
            customer1.IsMapped = false;
            customer1.ActionType = Constants.ActionType.None;
            CustomerData.Add(customer1);
            Collection<ArgusClientDto> ClientData = new Collection<ArgusClientDto>();
            ArgusClientDto clientData1 = new ArgusClientDto();
            clientData1.ClientId = 4;
            // clientData1.ClientCode = "00005";
            clientData1.CustomerId = 1;
            clientData1.IsMapped = false;
            clientData1.ActionType = Constants.ActionType.D;
            ClientData.Add(clientData1);

            ArgusClientDto clientData2 = new ArgusClientDto();
            clientData2.ClientId = 18;
            clientData2.ClientCode = "00004";
            clientData2.CustomerId = 2;
            clientData2.IsMapped = true;
            clientData2.ActionType = Constants.ActionType.I;
            ClientData.Add(clientData2);

            composite.ArgusCustomerDtoCollection = CustomerData;
            composite.ArgusClientDtoCollection = ClientData;
            composite.lobId = 5;
            var logResponse = Controller.SaveCustomerClientMapping(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");
        }

        [Test]
        public void SuccessForSaveRejectCodeMapping()
        {
            CompositeObject.SaveRejectCodeMapping composite = new CompositeObject.SaveRejectCodeMapping();
            Collection<PolicyRejectCodeDto> rejectcodedata = new Collection<PolicyRejectCodeDto>();
            PolicyRejectCodeDto rejectcode1 = new PolicyRejectCodeDto();
            rejectcode1.RejectCodeId = 7;
            rejectcode1.RejectCode= "99";
            rejectcode1.RejectCodeDesc = "test";
            rejectcode1.ActionType = Constants.ActionType.None;
            rejectcode1.IsMapped = true;
            rejectcode1.UpdatedBy = "SIT4034";
            rejectcodedata.Add(rejectcode1);

            PolicyRejectCodeDto rejectcode2 = new PolicyRejectCodeDto();
            rejectcode2.RejectCodeId = 6;
            rejectcode2.RejectCode = "88";
            rejectcode2.RejectCodeDesc = "Step Therapy ";
            rejectcode2.ActionType = Constants.ActionType.None;
            rejectcode2.IsMapped = true;
            rejectcode2.UpdatedBy = "SIT4034";
            rejectcodedata.Add(rejectcode2);
            composite.policyRejectCodeCollection = rejectcodedata;
            composite.policyTypeId = 2;
            var logResponse = Controller.SaveRejectCodeMapping(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");

        }

        [Test]
        public void RejectCodeCollectionNULL_SaveRejectCodeMapping()
        {

            CompositeObject.SaveRejectCodeMapping composite = new CompositeObject.SaveRejectCodeMapping();
            Collection<PolicyRejectCodeDto> rejectcodedata = new Collection<PolicyRejectCodeDto>();
            composite.policyTypeId = 1;
            var logResponse = Controller.SaveRejectCodeMapping(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");
        }

        [Test]
        public void InvalidPolicyTypeID_SaveRejectCodeMapping()
        {

            CompositeObject.SaveRejectCodeMapping composite = new CompositeObject.SaveRejectCodeMapping();
            Collection<PolicyRejectCodeDto> rejectcodedata = new Collection<PolicyRejectCodeDto>();
            PolicyRejectCodeDto rejectcode1 = new PolicyRejectCodeDto();
            rejectcode1.RejectCodeId = 7;
            rejectcode1.RejectCode = "99";
            rejectcode1.RejectCodeDesc = "test";
            rejectcode1.ActionType = Constants.ActionType.I;
            rejectcode1.IsMapped = true;
            rejectcode1.UpdatedBy = "SIT4034";
            rejectcodedata.Add(rejectcode1);

            PolicyRejectCodeDto rejectcode2 = new PolicyRejectCodeDto();
            rejectcode2.RejectCodeId = 6;
            rejectcode2.RejectCode = "88";
            rejectcode2.RejectCodeDesc = "Step Therapy ";
            rejectcode2.ActionType = Constants.ActionType.D;
            rejectcode2.IsMapped = true;
            rejectcode2.UpdatedBy = "SIT4034";
            rejectcodedata.Add(rejectcode2);
            composite.policyRejectCodeCollection = rejectcodedata;
            composite.policyTypeId = -11;
            var logResponse = Controller.SaveRejectCodeMapping(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");
        }

        [Test]
        public void SuccessForBatchUploadFileStatus()
        {
            CompositeObject.NFMYBBatchUploadFileStatus composite = new CompositeObject.NFMYBBatchUploadFileStatus();
            composite.fileStatus = "2";
            composite.policyTypeId = 7;
            var logResponse = Controller.NFMYBBatchUploadFileStatus(composite) as IActionResult;
            Assert.IsNotNull(logResponse);

        }

        [Test]
        public void MissingFileStatus_BatchUploadFileStatus()
        {
            CompositeObject.NFMYBBatchUploadFileStatus composite = new CompositeObject.NFMYBBatchUploadFileStatus();
            //composite.fileStatus = "2";
            composite.policyTypeId = 7;
            var logResponse = Controller.NFMYBBatchUploadFileStatus(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }

        [Test]
        public void InvalidPolicyTypeID_BatchUploadFileStatus()
        {
            CompositeObject.NFMYBBatchUploadFileStatus composite = new CompositeObject.NFMYBBatchUploadFileStatus();
            composite.fileStatus = "-1";
            composite.policyTypeId = -7;
            var logResponse = Controller.NFMYBBatchUploadFileStatus(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }

        [Test]
        public void SuccessForSaveArchiveFile()
        {
            BatchUploadFileDetailsDto filedata = new BatchUploadFileDetailsDto();
            filedata.FileName = "NF_Policy_Archive_Template.Test2_20190919224926643_20190920082731513.xlsx";
            filedata.FTPPathName = "/root_vdm_1/fs114/web_pharmacy/CentralizedFormulary/iRx/TEST/Data/In/BatchArchivePolicies";
            filedata.ErrorDescription = "";
            filedata.PolicyTypeId = 4;
            filedata.FileStatus = "ReadyToValidate";
            filedata.Action = "None";
            filedata.Active = true;
            filedata.UploadedBy = "SIT4034";
            filedata.UploadDate = "8/17/2020";
            var logResponse = Controller.SaveBatchArchiveFileStatus(filedata) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");

        }


        [Test]
        public void MissingFileName_SaveArchiveFile()
        {
            BatchUploadFileDetailsDto filedata = new BatchUploadFileDetailsDto();
            filedata.FTPPathName = "/root_vdm_1/fs114/web_pharmacy/CentralizedFormulary/iRx/TEST/Data/In/BatchArchivePolicies";
            filedata.ErrorDescription = "";
            filedata.PolicyTypeId = 4;
            filedata.FileStatus = "ReadyToValidate";
            filedata.Action = "None";
            filedata.Active = true;
            filedata.UploadedBy = "SIT4034";
            filedata.UploadDate = "8/17/2020";
            var logResponse = Controller.SaveBatchArchiveFileStatus(filedata) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }

        [Test]
        public void SuccessForBatchUploadAction()
        {
            CompositeObject.ApproveorRejectBatchUploadFile composite = new CompositeObject.ApproveorRejectBatchUploadFile();
            composite.fileId = 3;
            composite.status = "Rejected";
            composite.actionBy = "SIT4034";
            var logResponse = Controller.ApproveorRejectBatchUploadFile(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");

        }

        [Test]
        public void InvalidFileID_BatchUploadAction()
        {
            CompositeObject.ApproveorRejectBatchUploadFile composite = new CompositeObject.ApproveorRejectBatchUploadFile();
            composite.fileId = -3;
            composite.status = "Rejected";
            composite.actionBy = "SIT4034";
            var logResponse = Controller.ApproveorRejectBatchUploadFile(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }

        [Test]
        public void MissingFileStatus_BatchUploadAction()
        {
            CompositeObject.ApproveorRejectBatchUploadFile composite = new CompositeObject.ApproveorRejectBatchUploadFile();
            composite.fileId = 3;
            composite.actionBy = "SIT4034";
            

            var logResponse = Controller.ApproveorRejectBatchUploadFile(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }

        [Test]
        public void SuccessForBatchArchiveAction()
        {
            CompositeObject.ApproveorRejectBatchArchiveFile composite = new CompositeObject.ApproveorRejectBatchArchiveFile();
            composite.fileId = 9;
            composite.status = "ReadyToArchive";
            composite.actionBy = "SIT4034";
            composite.action= "Approve";
            var logResponse = Controller.ApproveorRejectBatchArchiveFile(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");

        }

        [Test]
        public void InvalidFileID_BatchArchiveAction()
        {
            CompositeObject.ApproveorRejectBatchArchiveFile composite = new CompositeObject.ApproveorRejectBatchArchiveFile();
            composite.fileId = -33;
            composite.status = "ReadyToArchive";
            composite.actionBy = "SIT4034";
            composite.action = "Approve";
            var logResponse = Controller.ApproveorRejectBatchArchiveFile(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }


        [Test]
        public void MissingFileStatus_BatchArchiveAction()
        {
            CompositeObject.ApproveorRejectBatchArchiveFile composite = new CompositeObject.ApproveorRejectBatchArchiveFile();
            composite.fileId = 10; ;

            composite.actionBy = "SIT4034";
            composite.action = "Approve";
            var logResponse = Controller.ApproveorRejectBatchArchiveFile(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        }

        [Test]
        public void SuccessForsaveLookBack()
        {
            Collection<RuleLookBackPeriodDto> parmeter = new Collection<RuleLookBackPeriodDto>();
            RuleLookBackPeriodDto lookback1 = new RuleLookBackPeriodDto();
            lookback1.LookBackId = 26;
            lookback1.LookBackValue = "6";
            lookback1.LookBackUnit = "Months";
            lookback1.ActionType = Constants.ActionType.None;
            lookback1.UpdatedBy = "SIT4034";
            lookback1.LookBackValueUnit = "6 Months";
            lookback1.IsEditable = true;
            parmeter.Add(lookback1);

            RuleLookBackPeriodDto lookback2 = new RuleLookBackPeriodDto();
            lookback2.LookBackId = 29;
            lookback2.LookBackValue = "450";
            lookback2.LookBackUnit = "Months";
            lookback2.ActionType = Constants.ActionType.None;
            lookback2.UpdatedBy = "SIT4034";
            lookback2.LookBackValueUnit = "450 Months";
            lookback2.IsEditable = true;
            parmeter.Add(lookback2);

            var logResponse = Controller.saveLookBack(parmeter) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");

        }

        [Test]
        public void MissingLookBackValue_saveLookBack()
        {
            Collection<RuleLookBackPeriodDto> parmeter = new Collection<RuleLookBackPeriodDto>();
            RuleLookBackPeriodDto lookback1 = new RuleLookBackPeriodDto();
            lookback1.LookBackId = 26;

            lookback1.LookBackUnit = "Months";
            lookback1.ActionType = Constants.ActionType.I;
            lookback1.UpdatedBy = "SIT4034";
            lookback1.LookBackValueUnit = "6 Months";
            lookback1.IsEditable = true;
            parmeter.Add(lookback1);

            RuleLookBackPeriodDto lookback2 = new RuleLookBackPeriodDto();
            lookback2.LookBackId = 29;
            lookback2.LookBackValue = "450";
            lookback2.LookBackUnit = "Months";
            lookback2.ActionType = Constants.ActionType.None;
            lookback2.UpdatedBy = "SIT4034";
            lookback2.LookBackValueUnit = "450 Months";
            lookback2.IsEditable = true;
            parmeter.Add(lookback2);

            var logResponse = Controller.saveLookBack(parmeter) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");
            var logResponse = ServiceCallsaveLookBack(parmeter);
            if (!logResponse.IsSuccessStatusCode)
            {
                JObject json = JObject.Parse(logResponse.Content.ReadAsStringAsync().Result);
                ResponseMessageDto responseStatus = new ResponseMessageDto();
                responseStatus.Code = (int)json["code"];
                responseStatus.Message = (string)json["message"];

                Assert.IsNotNull(logResponse);
                Assert.AreEqual(responseStatus.Message, "Procedure or function 'iRx_SaveRuleLookBackPeriodDetails' expects parameter '@LookBackValue', which was not supplied.");
                Assert.AreEqual(responseStatus.Code, StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// NUnit Test for GetAvailableClients
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>

        [Test]
        public void SuccessForGetAvailableClients()
        {
            CompositeObject.LobValue comp = new CompositeObject.LobValue();
            comp.lobId = 4;
            var logResponse = Controller.GetAvailableClients(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        /// <summary>
        /// NUnit Test for GetAvailableFormularies
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        [Test]
        public void SuccessForGetAvailableFormularies()
        {
            CompositeObject.SelectedFormularies comp = new CompositeObject.SelectedFormularies();
            comp.planYear = 2021;
            comp.lobId = 4;

            var logResponse = Controller.GetAvailableFormularies(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        /// <summary>
        /// NUnit Test for SelectedFormularies
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        [Test]
        public void SuccessForSelectedFormularies()
        {
            CompositeObject.SelectedFormularies comp = new CompositeObject.SelectedFormularies();
            comp.planYear = 2021;
            comp.lobId = 4;

            var logResponse = Controller.SelectedFormularies(comp) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        /// <summary>
        /// NUnit Test for SaveFormularyMapping
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        [Test]
        public void SuccessForSaveFormularyMapping()
        {
            Collection<SaveFormularyMappingDto> formularyMappingDto = new Collection<SaveFormularyMappingDto>();
            SaveFormularyMappingDto mappingDto = new SaveFormularyMappingDto();
            mappingDto.Lob = 5;
            mappingDto.PlanYear = 2020;
            mappingDto.FormularyId = "2016AHCA";
            mappingDto.FormularyName = "FL AHCA";
            mappingDto.UserId = "SIT4034";
            
            SaveFormularyMappingDto mappingDto1 = new SaveFormularyMappingDto();
            mappingDto1.Lob = 5;
            mappingDto1.PlanYear = 2020;
            mappingDto1.FormularyId = "2020CO5P";
            mappingDto1.FormularyName = "Rx5 Plus Colorado";
            mappingDto1.UserId = "SIT4034";

            formularyMappingDto.Add(mappingDto);
            formularyMappingDto.Add(mappingDto1);

            var logResponse = Controller.SaveFormularyMapping(formularyMappingDto) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        /// <summary>
        /// NUnit Test for SavePolicyOwner
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        [Test]
        public void SuccessForSavePolicyOwner()
        {
            Collection<PolicyOwnerDto> policyOwnerDtoCollection = new Collection<PolicyOwnerDto>();
            PolicyOwnerDto ownerDto = new PolicyOwnerDto();
            ownerDto.PolicyOwnerId = 56;
            ownerDto.OwnerName = "Intownercheck";
            ownerDto.OwnerEmail = "Int@humana.com";
            ownerDto.ActionType = Constants.ActionType.I;
            ownerDto.UpdatedBy = "SIT4034";
            ownerDto.IsActive = true;
            ownerDto.Status = "Active";

            PolicyOwnerDto ownerDto1 = new PolicyOwnerDto();
            ownerDto1.PolicyOwnerId = 46;
            ownerDto1.OwnerName = "test";
            ownerDto1.OwnerEmail = "Test@humana.com";
            ownerDto1.ActionType = Constants.ActionType.U;
            ownerDto1.UpdatedBy = "SHU678";
            ownerDto1.IsActive = false;
            ownerDto1.Status = "In active";

            policyOwnerDtoCollection.Add(ownerDto);
            policyOwnerDtoCollection.Add(ownerDto1);

            var logResponse = Controller.SavePolicyOwner(policyOwnerDtoCollection) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        /// <summary>
        /// NUnit Test for RuleLookBackPeriodList
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        [Test]
        public void SuccessForRuleLookBackPeriodList()
        {
            var logResponse = UTController.RuleLookBackPeriodList() as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        /// <summary>
        /// NUnit Test for PolicyOwnerList
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        [Test]
        public void SuccessForPolicyOwnerList()
        {
            var logResponse = UTController.PolicyOwnerList() as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        /// <summary>
        /// NUnit Test for PolicyTypeList
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        [Test]
        public void SuccessForPolicyTypeList()
        {
            var logResponse = UTController.PolicyTypeList() as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        /// <summary>
        /// NUnit Test for AvailableRejectCodes
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        [Test]
        public void SuccessForAvailableRejectCodes()
        {

            CompositeObject.AvailableRejectCodes composite = new CompositeObject.AvailableRejectCodes();
            composite.policyTypeId = 3;

            var logResponse = Controller.AvailableRejectCodes(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        /// <summary>
        /// NUnit Test for SaveRejectCodes
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        [Test]
        public void SuccessForSaveRejectCodes()
        {
            Collection<PolicyRejectCodeDto> rejectCodeDtoCollection = new Collection<PolicyRejectCodeDto>();
            PolicyRejectCodeDto policyReject = new PolicyRejectCodeDto();
            policyReject.RejectCodeId = 23;
            policyReject.RejectCode = "78";
            policyReject.RejectCodeDesc = "Guidance1";
            policyReject.ActionType = Constants.ActionType.I;
            policyReject.IsMapped = true;
            policyReject.UpdatedBy = "SIT4034";

            PolicyRejectCodeDto policyReject1 = new PolicyRejectCodeDto();
            policyReject1.RejectCodeId = 22;
            policyReject1.RejectCode = "75";
            policyReject1.RejectCodeDesc = "Prior Authorization";
            policyReject1.ActionType = Constants.ActionType.U;
            policyReject1.IsMapped = false;
            policyReject1.UpdatedBy = "SIT4034";

            PolicyRejectCodeDto policyReject2 = new PolicyRejectCodeDto();
            policyReject2.RejectCodeId = 17;
            policyReject2.RejectCode = "76";
            policyReject2.RejectCodeDesc = "Prior Author";
            policyReject2.ActionType = Constants.ActionType.D;
            policyReject2.IsMapped = true;
            policyReject2.UpdatedBy = "SIT4034";

            rejectCodeDtoCollection.Add(policyReject);
            rejectCodeDtoCollection.Add(policyReject1);
            rejectCodeDtoCollection.Add(policyReject2);

            var logResponse = Controller.SaveRejectCodes(rejectCodeDtoCollection) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }

        /// <summary>
        /// NUnit Test for RejectCodeList
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        [Test]
        public void SuccessForRejectCodeList()
        {
            var logResponse = UTController.RejectCodeList() as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        }


        private HttpResponseMessage ServiceCallCheckLobMapping(int contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("CheckLobMapping");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }
        private HttpResponseMessage ServiceCallCheckPolicyOwnerMappping(Int16 contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("CheckPolicyOwnerMappping");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }
        private HttpResponseMessage ServiceCallCustomers(Int16 contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("Customers");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }
        private HttpResponseMessage ServiceCallSaveLobDetails(Collection<PolicyLobDto> contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("SaveLob");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }
        private HttpResponseMessage ServiceCallSaveCustomerClientMapping(CompositeObject.SaveCustomerClientMapping contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("SaveCustomerClientMapping");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }
        private HttpResponseMessage ServiceCallSaveRejectCodeMapping(CompositeObject.SaveRejectCodeMapping contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("SaveRejectCodeMapping");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }
        private HttpResponseMessage ServiceCallBatchUploadFileStatus(CompositeObject.NFMYBBatchUploadFileStatus contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("BatchUploadFileStatus");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }
        private HttpResponseMessage ServiceCallSaveArchiveFile(BatchUploadFileDetailsDto contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("SaveArchiveFile");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }

        [Test]
        public void SuccessForBatchArchiveFileStatus()
        {
            CompositeObject.NFMYBBatchUploadFileStatus composite = new CompositeObject.NFMYBBatchUploadFileStatus();
            composite.fileStatus = "2";
            composite.policyTypeId = 7;
            var logResponse = Controller.NFMYBBatchArchiveFileStatus(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
        private HttpResponseMessage ServiceCallBatchUploadAction(CompositeObject.ApproveorRejectBatchUploadFile contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("BatchUploadAction");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }

        [Test]
        public void MissingFileStatus_BatchArchiveFileStatus()
        {
            CompositeObject.NFMYBBatchUploadFileStatus composite = new CompositeObject.NFMYBBatchUploadFileStatus();
            //composite.fileStatus = "2";
            composite.policyTypeId = 7;
            var logResponse = Controller.NFMYBBatchArchiveFileStatus(composite) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");
        private HttpResponseMessage ServiceCallBatchArchiveAction(CompositeObject.ApproveorRejectBatchArchiveFile contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("BatchArchiveAction");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }

        [Test]
        public void MissingFileName_SaveUploadFile()
        {
            BatchUploadFileDetailsDto filedata = new BatchUploadFileDetailsDto();
            filedata.FTPPathName = "/root_vdm_1/fs114/web_pharmacy/CentralizedFormulary/iRx/TEST/Data/In/NFBatchUpload";
            filedata.ErrorDescription = "";
            filedata.PolicyTypeId = 4;
            filedata.FileStatus = "ReadyToValidate";
            filedata.Action = "None";
            filedata.Active = true;
            filedata.UploadedBy = "SIT4034";
            filedata.UploadDate = "8/17/2020";
            var logResponse = Controller.SaveBatchUploadFileStatus(filedata) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");
        private HttpResponseMessage ServiceCallsaveLookBack(Collection<RuleLookBackPeriodDto> contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("saveLookBack");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }

        [Test]
        public void SuccessForSaveUploadFile()
        {
            BatchUploadFileDetailsDto filedata = new BatchUploadFileDetailsDto();
            filedata.FileName = "NF_Policy_Archive_Template.Test2_20190919224926643_20190920082731513.xlsx";
            filedata.FTPPathName = "/root_vdm_1/fs114/web_pharmacy/CentralizedFormulary/iRx/TEST/Data/In/NFBatchUpload";
            filedata.ErrorDescription = "";
            filedata.PolicyTypeId = 4;
            filedata.FileStatus = "ReadyToValidate";
            filedata.Action = "None";
            filedata.Active = true;
            filedata.UploadedBy = "SIT4034";
            filedata.UploadDate = "8/17/2020";
            var logResponse = Controller.SaveBatchUploadFileStatus(filedata) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "200");
        private HttpResponseMessage ServiceCallCheckTherapeuticCategoryMapping(Int16 contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("CheckTherapeuticCategoryMapping");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }

        [Test]
        public void TemplateNULL_SaveTemplateFile()
        {
            PolicyTemplateDto filedata = new PolicyTemplateDto();
            
            var logResponse = Controller.SavePolicyTemplate(filedata) as IActionResult;
            Assert.IsNotNull(logResponse);
            var actualJson = JsonConvert.SerializeObject(logResponse);
            var jsonObj = JObject.Parse(actualJson);
            var response = jsonObj["StatusCode"].ToString();
            Assert.AreEqual(response, "404");

        private HttpResponseMessage ServiceCallCheckSubCategoryMapping(Int16 contents)
        {
            using (var httpClient = new HttpClient())
            {
                string URL = GetValueFromNUTest_Json("CheckSubCategoryMapping");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(URL, content).Result;
                return response;
            }

        }
        private string GetValueFromNUTest_Json(string KeyName)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("NUnit_json.json").Build();
            string KeyValue = configuration[KeyName];
            return KeyValue;
        }
    }
}