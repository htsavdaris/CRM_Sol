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
    public class ForeasController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ForeasController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet, AllowAnonymous]
        public ActionResult<List<Foreas>> Get()
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            List<Foreas> foreasList;
            using (ForeasDac dac = new ForeasDac(connStr))
            {
                foreasList = dac.GetAll();
                return Ok(foreasList);
            }
        }

        // GET: api/Citizen/5
        [HttpGet("{id}", Name = "Get"), AllowAnonymous]
        public ActionResult<Foreas> Get(long id)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            Foreas oForeas;
            using (ForeasDac dac = new ForeasDac(connStr))
            {
                oForeas = dac.Get(id);
                return Ok(oForeas);
            }
        }

        [HttpGet("{treecode}", Name = "Get"), AllowAnonymous]
        public ActionResult<List<Foreas>> Get(string Treecode)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            List<Foreas> foreasList;
            using (ForeasDac dac = new ForeasDac(connStr))
            {
                foreasList = dac.GetByTreeCode(Treecode);
                return Ok(foreasList);
            }
        }

        // POST: api/Citizen
        [HttpPost, AllowAnonymous]
        public IActionResult Post([FromBody] Foreas oForeas)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            using (ForeasDac dac = new ForeasDac(connStr))
            {
                long id = dac.Insert(oForeas);
                return CreatedAtRoute("Foreas", new { id = id }, oForeas);
            }
        }

        // PUT: api/Citizen/5
        [HttpPut("{id}"), AllowAnonymous]
        public IActionResult Put(int id, [FromBody] Foreas oForeas)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            using (ForeasDac dac = new ForeasDac(connStr))
            {
                bool isSuccess = dac.Update(oForeas);
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