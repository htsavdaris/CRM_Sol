using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CRM_DB;
using Microsoft.AspNetCore.Authorization;

namespace CRM_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {

        private readonly IConfiguration configuration;
        public CitizenController(IConfiguration config)
        {
            this.configuration = config;
        }

        // GET: api/Citizen
        [HttpGet, AllowAnonymous]
        public ActionResult<List<CitizenProfile>> Get()
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            List<CitizenProfile> citizenList;
            using (CitizenProfileDac dac = new CitizenProfileDac(connStr))
            {
                citizenList = dac.GetAll();
                return Ok(citizenList);
            }
        }

        // GET: api/Citizen/5
        [HttpGet("{id}"), AllowAnonymous]
        public ActionResult<CitizenProfile> Get(long id)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            CitizenProfile citizen;
            using (CitizenProfileDac dac = new CitizenProfileDac(connStr))
            {
                citizen = dac.Get(id);
                return Ok(citizen);
            }
        }

        // POST: api/Citizen
        [HttpPost, AllowAnonymous]
        public IActionResult Post([FromBody] CitizenProfile citizen)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            using (CitizenProfileDac dac = new CitizenProfileDac(connStr))
            {
                long id = dac.Insert(citizen);
                return CreatedAtRoute("Citizen", new { id = id }, citizen);
            }
        }

        // PUT: api/Citizen/5
        [HttpPut("{id}"), AllowAnonymous]
        public IActionResult Put(int id, [FromBody] CitizenProfile citizen)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            using (CitizenProfileDac dac = new CitizenProfileDac(connStr))
            {
                bool isSuccess = dac.Update(citizen);
            }
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}"), AllowAnonymous]
        public void Delete(int id)
        {
        }
    }
}
