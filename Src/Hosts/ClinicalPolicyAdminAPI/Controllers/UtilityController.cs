/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using System;
using System.Collections.Generic;
using Common;
using Common.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Server.DataAccessObjects;

namespace ClinicalPolicyAdminAPI.Controllers
{
    [Route("api/Utility")]
    [ApiController]
    public class UtilityController : BaseController
    {
        private readonly IConfiguration _config;

        public UtilityController(IConfiguration config)
        {
            _config = config;
        }


        [Route("lookuplist")]
        [HttpPost]
        /// <summary>
        /// This look up function returns data based on function code given below (ex:lob,PolicyType)
        /// Lob,PolicyType,TherapeuticCategory,SubCategory,PolicyOwner,RuleConcept,RevisionType,UpdateTyp,LobCF
        /// </summary>
        public IActionResult PolicyLookUpDataList(LookupDataDto lookupDto)
        {

            try
            {
                if (string.IsNullOrEmpty(lookupDto.functionCode))
                {
                    return NotFound(StatusCodes.Status400BadRequest);
                }
                else
                {
                    var Result = new ClinicalPolicyAdminDao(_config).GetLookUpList(lookupDto.functionCode);
                    return Ok(Result);
                }

            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get Master Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("masterList")]
        [HttpGet]
        public IActionResult PolicyMasterDataList()
        {

            try
            {
                var Result = new MasterDataDao(_config).GetPolicyMasterData();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get lob Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("LobList")]
        [HttpGet]
        public IActionResult LobList()
        {

            try
            {
                var Result = new MasterDataDao(_config).LobList();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }
       

        /// <summary>
        /// Get PolicyList Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("PolicyTypeList")]
        [HttpGet]
        public IActionResult PolicyTypeList()
        {

            try
            {
                var Result = new MasterDataDao(_config).PolicyType();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get TherapeuticCategory Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("TherapeuticCategoryList")]
        [HttpGet]
        public IActionResult TherapeuticCategoryList()
        {

            try
            {
                var Result = new MasterDataDao(_config).TherapeuticCategory();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get SubCategory Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("SubCategoryList")]
        [HttpGet]
        public IActionResult SubCategoryList()
        {

            try
            {
                var Result = new MasterDataDao(_config).SubCategory();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get PolicyOwner Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("PolicyOwnerList")]
        [HttpGet]
        public IActionResult PolicyOwnerList()
        {

            try
            {
                var Result = new MasterDataDao(_config).PolicyOwner();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get LookBack Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("RuleLookBackPeriodList")]
        [HttpGet]
        public IActionResult RuleLookBackPeriodList()
        {

            try
            {
                var Result = new MasterDataDao(_config).RuleLookBackPeriod();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get RejectCode Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("RejectCodeList")]
        [HttpGet]
        public IActionResult RejectCodeList()
        {

            try
            {
                var Result = new MasterDataDao(_config).RejectCode();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get Template Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("TemplateList")]
        [HttpGet]
        public IActionResult TemplateList()
        {

            try
            {
                var Result = new MasterDataDao(_config).Template();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Get RuleConcept Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("RuleConceptList")]
        [HttpGet]
        public IActionResult RuleConceptList()
        {

            try
            {
                var Result = new MasterDataDao(_config).RuleConcept();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get PolicyTypeDefault Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("PolicyTypeDefaultList")]
        [HttpGet]
        public IActionResult PolicyTypeDefault()
        {

            try
            {
                var Result = new MasterDataDao(_config).PolicyTypeDefault();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get RevisionType Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("RevisionTypeList")]
        [HttpGet]
        public IActionResult RevisionTypeList()
        {

            try
            {
                var Result = new MasterDataDao(_config).RevisionType();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get UpdateType Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("UpdateTypeList")]
        [HttpGet]
        public IActionResult UpdateTypeList()
        {

            try
            {
                var Result = new MasterDataDao(_config).UpdateType();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Get CPLobList Data For Policy
        /// </summary>
        /// <returns></returns>
        [Route("CPLobList")]
        [HttpGet]
        public IActionResult CPLobList()
        {

            try
            {
                var Result = new MasterDataDao(_config).CPLob();
                return Ok(Result);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow, _config);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
