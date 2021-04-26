using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ninja2021V.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class samuraiController : ControllerBase
    {
        List<string> stringList = new List<string>
        {
            "value1", "value2", "value3"
        };

        // GET: api/samurai
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return stringList;
        }

        // GET: api/samurai/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var result = stringList.Where((flodhest) => flodhest.Contains(id + "")).ToList().FirstOrDefault();

            return result;
        }

        // POST: api/samurai
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/samurai/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
