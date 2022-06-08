/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using Common;
using Common.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Server.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace ClinicalPolicyAdminAPI.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class AdminController : BaseController
    {

        private readonly IConfiguration _config;

        public AdminController(IConfiguration config)
        {
            _config = config;
        }

        [Route("HeartBeat")]
        [HttpGet]
        public string HeartBeat()
        {
                return "Ok";
        }

        [Route("GetLookUpFunctions")]
        [HttpGet]
        public IActionResult GetLookUpFunctions(string Key)
        {

            return null;
        }

        /// <summary>
        /// CheckIfPolicyExists
        /// </summary>
        /// <param name="lobId"></param>
        /// <returns></returns>
        [Route("CheckLobMapping")]
        [HttpPost]
        public IActionResult CheckLobMapping(CompositeObject.LobValue composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (composite != null)
                {
                    if (composite.lobId > 0)
                    {
                        bool response = new ClinicalPolicyAdminDao(_config).CheckIfPolicyExists(composite.lobId);
                        return Ok(response);
                    }
                    else
                    {
                        objMessage.Code = StatusCodes.Status400BadRequest;
                        objMessage.Message = Constants.Message.BadRequest;
                        return NotFound(objMessage);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }

        }

        /// <summary>
        /// Save Line Of Business Details
        /// </summary>
        /// <param name="policyLobDtoCollection"></param>
        /// <returns></returns>
        [Route("SaveLob")]
        [HttpPost]
        public IActionResult SaveLobDetails([FromBody]Collection<PolicyLobDto> policyLobDtoCollection)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (policyLobDtoCollection != null)
                {
                    new ClinicalPolicyAdminDao(_config).SaveLob(policyLobDtoCollection);
                    objMessage.Code = StatusCodes.Status200OK;
                    objMessage.Message = Constants.Message.Success;
                    return Ok(objMessage);
                }
                else
                {

                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }


            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }

        }

        /// <summary>
        /// Get Formulary Details
        /// </summary>
        /// <returns></returns>
        [Route("FormularyDetails")]
        [HttpGet]
        public IActionResult GetFormularyDetails()
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                FormularyMappingDto mappingDto = new ClinicalPolicyAdminDao(_config).GetFormularyDetails();
                return Ok(mappingDto);


            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }

        /// <summary>
        /// PrimaryLobList
        /// </summary>
        /// <returns></returns>
        [Route("PrimarySubCategoryLobList")]
        [HttpGet]
        public IActionResult PrimarySubCategoryLobList()
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();

            try
            {
               
                var primaryLob = new ClinicalPolicyAdminDao(_config).PrimaryLobSubCategoryList();
                return Ok(primaryLob);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }
        /// <summary>
        ///  Get Customers Data For LOB mapping details
        /// </summary>
        /// <param name="lobId"></param>
        /// <returns></returns>
        [Route("Customers")]
        [HttpPost]
        public IActionResult GetCustomers(CompositeObject.LobValue composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (composite != null)
                {
                    if (composite.lobId > 0)
                    {
                        Collection<ArgusCustomerDto> response = new ClinicalPolicyAdminDao(_config).GetCustomers(composite.lobId);
                        return Ok(response);
                    }
                    else
                    {
                        objMessage.Code = StatusCodes.Status400BadRequest;
                        objMessage.Message = Constants.Message.BadRequest;
                        return NotFound(objMessage);
                    }
                }
                else
                {
                    return NotFound();
                }
                

            }
            catch (Exception ex)
            {
                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }

        /// <summary>
        /// Get Clients Data For LOB mapping details
        /// </summary>
        /// <param name="lobId"></param>
        /// <returns></returns>
        [Route("AvailableClients")]
        [HttpPost]
        public IActionResult GetAvailableClients(CompositeObject.LobValue composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (composite != null)
                { 
                if (composite.lobId > 0)
                {
                    Collection<ArgusClientDto> response = new ClinicalPolicyAdminDao(_config).GetAvailableClients(composite.lobId);
                    return Ok(response);
                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }


        /// <summary>
        /// Get Available Formulary Id Details
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        [Route("AvailableFormularies")]
        [HttpPost]
        public IActionResult GetAvailableFormularies([FromBody]CompositeObject.SelectedFormularies composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();

            try
            {
                if (composite != null)
                {
                    List<FormularyDetailsDto> response = new ClinicalPolicyAdminDao(_config).GetUserFormularyIdDetails(composite.planYear, composite.lobId);
                    return Ok(response);
                }

                else
                {
                    return NotFound();
                }

        }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }

        /// <summary>
        /// Get Saved Formulary Id Details
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        [Route("SelectedFormularies")]
        [HttpPost]
        public IActionResult SelectedFormularies([FromBody]CompositeObject.SelectedFormularies composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (composite != null)
                { 
                List<FormularyDetailsDto> response = new ClinicalPolicyAdminDao(_config).GetSavedFormularyIdDetails(composite.planYear, composite.lobId);
                return Ok(response);
                }

                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }

        /// <summary>
        /// Save CustomerClientMapping Mapping Details
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        [Route("SaveCustomerClientMapping")]
        [HttpPost]
        public IActionResult SaveCustomerClientMapping([FromBody]CompositeObject.SaveCustomerClientMapping composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();

            try
            {
<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<AUTO GENERATED BY CONFLICT EXTENSION<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< SonarScan22.06
                if (composite.ArgusCustomerDtoCollection != null && composite.LobId > 0)
====================================AUTO GENERATED BY CONFLICT EXTENSION====================================
                if (composite != null)
                { 
                if (composite.ArgusCustomerDtoCollection != null && composite.lobId > 0)
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>AUTO GENERATED BY CONFLICT EXTENSION>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> MasterSonarScan
                  
                {
                    Collection<ArgusCustomerDto> ArgusCustomerDtoCollection = composite.ArgusCustomerDtoCollection;
                    Collection<ArgusClientDto> ArgusClientDtoCollection = composite.ArgusClientDtoCollection;
                    Int16 lobId = composite.LobId;
                    new ClinicalPolicyAdminDao(_config).SaveLobMappingDetails(ArgusCustomerDtoCollection, ArgusClientDtoCollection, lobId);
                    objMessage.Code = StatusCodes.Status200OK;
                    objMessage.Message = Constants.Message.Success;
                    return Ok(objMessage);
                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }
                }

                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }


        /// <summary>
        /// Save Lob Formulary Mapping Details
        /// </summary>
        /// <param name="formularyMappingDto"></param>
        /// <returns></returns>
        [Route("SaveFormularyMapping")]
        [HttpPost]
        public IActionResult SaveFormularyMapping([FromBody]Collection<SaveFormularyMappingDto> formularyMappingDto)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (formularyMappingDto != null)
                {
                    Collection<SaveFormularyMappingDto> non = formularyMappingDto;
                    string json = JsonConvert.SerializeObject(non);
                    DataTable pDt = JsonConvert.DeserializeObject<DataTable>(json);
                    new ClinicalPolicyAdminDao(_config).SaveFormularyMappingDetails(pDt);
                    objMessage.Code = StatusCodes.Status200OK;
                    objMessage.Message = Constants.Message.Success;
                    return Ok(objMessage);
                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }

            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }


        /// <summary>
        /// Save Look Back Period
        /// </summary>
        /// <param name="ruleLookBackPeriodCollection"></param>
        /// <returns></returns>
        [Route("saveLookBack")]
        [HttpPost]
        public IActionResult saveLookBack([FromBody]Collection<RuleLookBackPeriodDto> ruleLookBackPeriodCollection)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();

            try
            {
                if (ruleLookBackPeriodCollection != null)
                {

                    new ClinicalPolicyAdminDao(_config).SaveLookBackPeriod(ruleLookBackPeriodCollection);
                    objMessage.Code = StatusCodes.Status200OK;
                    objMessage.Message = Constants.Message.Success;
                    return Ok(objMessage);
                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }


            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }


        /// <summary>
        /// CheckPolicyOwnerPolicyMapping
        /// </summary>
        /// <param name="policyOwnerId"></param>
        /// <returns></returns>
        [Route("CheckPolicyOwnerMappping")]
        [HttpPost]
        public IActionResult ActivateDeactivatePolicyOwner(CompositeObject.PoliyOwnerIdValue composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (composite != null)
                {
                if (composite.PoliyOwnerId > 0)
                {
                    bool response = new ClinicalPolicyAdminDao(_config).CheckPolicyOwnerPolicyMapping(composite.PoliyOwnerId);
                    return Ok(response);
                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }

        }



        /// <summary>
        /// Save Policy Owner
        /// </summary>
        /// <param name="policyOwnerDtoCollection"></param>
        /// <returns></returns>
        [Route("SavePolicyOwner")]
        [HttpPost]
        public IActionResult SavePolicyOwner(Collection<PolicyOwnerDto> policyOwnerDtoCollection)
        {

            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (policyOwnerDtoCollection != null)
                {
                    new ClinicalPolicyAdminDao(_config).SavePolicyOwnerGrid(policyOwnerDtoCollection);
                    objMessage.Code = StatusCodes.Status200OK;
                    objMessage.Message = Constants.Message.Success;
                    return Ok(objMessage);

                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }


            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }

        }


        /// <summary>
        /// Get Data For Policy Type Reject Code
        /// </summary>
        /// <param name="policyTypeId"></param>
        /// <returns></returns>
        [Route("AvailableRejectCodes")]
        [HttpPost]
        public IActionResult AvailableRejectCodes(CompositeObject.AvailableRejectCodes composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {

                

                if (composite != null)
                {
                    if (composite.PolicyTypeId > 0)

                    {
                    Collection<PolicyRejectCodeDto> response = new ClinicalPolicyAdminDao(_config).GetPolicyTypeRejectCodeMapping(composite.PolicyTypeId);
                    return Ok(response);
                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }



        /// <summary>
        /// Save Reject Codes
        /// </summary>
        /// <param name="rejectCodeDtoCollection"></param>
        /// <returns></returns>
        [Route("SaveRejectCodes")]
        [HttpPost]
        public IActionResult SaveRejectCodes(Collection<PolicyRejectCodeDto> rejectCodeDtoCollection)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (rejectCodeDtoCollection != null)
                {
                    new ClinicalPolicyAdminDao(_config).SaveRejectCodesDetails(rejectCodeDtoCollection);
                    objMessage.Code = StatusCodes.Status200OK;
                    objMessage.Message = Constants.Message.Success;
                    return Ok(objMessage);

                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }
        }


        /// <summary>
        /// SaveMappedRejectCode
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        [Route("SaveRejectCodeMapping")]
        [HttpPost]
        public IActionResult SaveRejectCodeMapping([FromBody]CompositeObject.SaveRejectCodeMapping composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (composite != null)
                { 
                if (composite.policyRejectCodeCollection != null && composite.policyTypeId > 0)
                {
                    new ClinicalPolicyAdminDao(_config).SaveMappedRejectCodeDetails(composite.policyRejectCodeCollection, composite.policyTypeId);
                    objMessage.Code = StatusCodes.Status200OK;
                    objMessage.Message = Constants.Message.Success;
                    return Ok(objMessage);

                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);

            }
        }


        /// <summary>
        /// CheckTherapeuticCategoryPolicyMapping
        /// </summary>
        /// <param name="therapeuticCategoryId"></param>
        /// <returns></returns>
        [Route("CheckTherapeuticCategoryMapping")]
        [HttpPost]
        public IActionResult CheckTherapeuticCategoryMapping(CompositeObject.therapeuticCategoryIdIdValue composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if(composite != null)
                { 
                if (composite.therapeuticCategoryId > 0)
                {
                    bool response = new ClinicalPolicyAdminDao(_config).CheckTherapeuticCategoryPolicyMapping(composite.therapeuticCategoryId);
                    return Ok(response);
                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }

        }


        /// <summary>
        /// Save Therapeutic Category
        /// </summary>
        /// <param name="therapeuticCategoryDtoCollection"></param>
        /// <returns></returns>
        [Route("SaveTherapeuticCategory")]
        [HttpPost]
        public IActionResult SaveTherapeuticCategory([FromBody]Collection<TherapeuticCategoryDto> therapeuticCategoryDtoCollection)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (therapeuticCategoryDtoCollection != null)
                {
                    new ClinicalPolicyAdminDao(_config).SaveTherapeuticCategory(therapeuticCategoryDtoCollection);
                    objMessage.Code = StatusCodes.Status200OK;
                    objMessage.Message = Constants.Message.Success;
                    return Ok(objMessage);
                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }

            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);

            }

        }



        /// <summary>
        /// CheckSubCategoryPolicyMapping
        /// </summary>
        /// <param name="subCategoryId"></param>
        /// <returns></returns>
        [Route("CheckSubCategoryMapping")]
        [HttpPost]
        public IActionResult CheckSubCategoryMapping(CompositeObject.subCategoryIdValue composite)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (composite != null)
                { 
                if (composite.subCategoryId > 0)
                {
                    bool response = new ClinicalPolicyAdminDao(_config).CheckSubCategoryPolicyMapping(composite.subCategoryId);
                    return Ok(response);
                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }

        }


        /// <summary>
        /// Save Sub Category
        /// </summary>
        /// <param name="subCategoryDtoCollection"></param>
        /// <returns></returns>
        [Route("SaveSubCategory")]
        [HttpPost]
        public IActionResult SaveSubCategory([FromBody]Collection<SubCategoryDto> subCategoryDtoCollection)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();
            try
            {
                if (subCategoryDtoCollection != null)
                {
                    new ClinicalPolicyAdminDao(_config).SaveSubCategory(subCategoryDtoCollection);
                    objMessage.Code = StatusCodes.Status200OK;
                    objMessage.Message = Constants.Message.Success;
                    return Ok(objMessage);

                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }


            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }

        }


        /// <summary>
        /// SavePolicyTemplate
        /// </summary>
        /// <param name="policyTemplateDto"></param>
        /// <returns></returns>
        [Route("SavePolicyTemplate")]
        [HttpPost]
        public IActionResult SavePolicyTemplate([FromBody]PolicyTemplateDto policyTemplateDto)
        {
            ResponseMessageDto objMessage = new ResponseMessageDto();

            try
            {
                if (policyTemplateDto != null)
                {
                    new ClinicalPolicyAdminDao(_config).SavePolicyTemplate(policyTemplateDto);
                    objMessage.Code = StatusCodes.Status200OK;
                    objMessage.Message = Constants.Message.Success;
                    return Ok(objMessage);

                }
                else
                {
                    objMessage.Code = StatusCodes.Status400BadRequest;
                    objMessage.Message = Constants.Message.BadRequest;
                    return NotFound(objMessage);
                }
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                objMessage.Code = StatusCodes.Status500InternalServerError;
                objMessage.Message = ex.Message;
                return NotFound(objMessage);
            }

        }
    }
}
