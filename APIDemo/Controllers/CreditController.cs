using Microsoft.AspNetCore.Mvc;
using APIDemo.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditController : ControllerBase
    {
        private readonly ILogger<CreditController> _logger;
        public CreditController(ILogger<CreditController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetCreditTypes")]
        public IEnumerable<Credit> Get()
        {
            var creditTypes = new List<Credit>();
            creditTypes.Add(new Credit(12, 12, 200000, 20, "Instant kes"));
            return creditTypes;
        }

        /*  [HttpPost("StoreCredit")]
          public async Task<ActionResult<Credit>> PostCredit([FromBody] Credit credit)
          {
              if (!ModelState.IsValid) { 
              return BadRequest(ModelState);
              }

              return CreatedAtAction("GetCredit", new {  id = credit.Id }, credit);
          }
        */
    }
}