using MedicalFacilityAPI.Models;
using MedicalFacilityAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MedicalFacilityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolmedController : ControllerBase
    {
        private PolmedService _polmedService;
        public PolmedController()
        {
            _polmedService = new PolmedService();
        }

        /// <summary>
        /// Returns available terms for given parameters
        /// </summary>
        /// <param name="dateFrom">Date from</param>
        /// <param name="dateTo">Date to</param>
        /// <param name="specialisation">Medical specialisation</param>
        /// <param name="doctor">Doctor phrase</param>
        /// <returns>List of available terms</returns>
        [HttpGet]
        [Route("terms")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<TermModel>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetTerms([FromQuery] DateTime dateFrom, DateTime dateTo, string specialisation, string doctor = null)
        {
            try
            {
                return Ok(_polmedService.SearchTerms(dateFrom, dateTo, specialisation, doctor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
