using MedicalFacilityAPI.Models;
using MedicalFacilityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MedicalFacilityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LuxmedController : ControllerBase
    {
        private LuxmedService _luxmedService;
        public LuxmedController()
        {
            _luxmedService = new LuxmedService();
        }


        /// <summary>
        /// Returns available terms for given parameters
        /// </summary>
        /// <param name="dateFrom">Date from</param>
        /// <param name="dateTo">Date to</param>
        /// <param name="serviceId">Medical sevice identifier</param>
        /// <param name="doctor">Doctor phrase</param>
        /// <returns>List of available terms</returns>
        [HttpGet]
        [Route("terms")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<TermModel>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetTerms([FromQuery] DateTime dateFrom, DateTime dateTo, long serviceId, string doctor = null)
        {
            try
            {
                return Ok(_luxmedService.SearchTerms(dateFrom, dateTo, serviceId, doctor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
