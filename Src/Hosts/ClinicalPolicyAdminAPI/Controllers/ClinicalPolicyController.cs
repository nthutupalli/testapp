using Common;
using Common.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Server.DataAccessObjects;
using System;
using System.Collections.Generic;

namespace ClinicalPolicyAdminAPI.Controllers
{
    [Route("api/ClinicalPolicy")]
    [ApiController]
    public class ClinicalPolicyController : BaseController
    {

        private readonly IConfiguration _config;

        public ClinicalPolicyController(IConfiguration config)
        {
            _config = config;
        }

        [Route("HeartBeat")]
        [HttpGet]
        public string HeartBeat()
        {
            try
            {
                //string key = _config.GetValue<string>("VaultUrl");
                return "Ok";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }

        [Route("GetLookUpFunctions")]
        [HttpGet]
        public IEnumerable<Lookupdto> GetLookUpFunctions([FromBody]Lookupdto lookup)
        {
           
            return null;
        }

        [Route("SearchPolicy")]
        [HttpPost]
        public ActionResult SearchPolicyList(ClinicalPolicySearchDto ClinicalPolicyDto)
        {
            //var json = new JavaScriptSerializer().Serialize(ClinicalPolicyDto);
            if (ClinicalPolicyDto == null) {
                return NotFound(StatusCodes.Status400BadRequest);
            }
            List<ClinicalPolicySearchDto> _searchResult = null;
            try
            {

                ClinicalPolicyDto.pageSize = 500;
                ClinicalPolicyDto.pageIndex = 1;
                _searchResult = new ClinicalPolicyDao().SearchPolicies(ClinicalPolicyDto);
                return Ok(_searchResult);
                //string responsedata = JsonConvert.SerializeObject(objresult);
            }
            catch (Exception ex)
            {

                BaseController.log(ex.Message, Constants.ErrorMessage.LogEventTypeError, Constants.ErrorMessage.LogSeverityLow);
                return NotFound(StatusCodes.Status500InternalServerError);
            }
            

        }
    }
}
