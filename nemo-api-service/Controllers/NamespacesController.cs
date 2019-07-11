using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using k8s;

namespace nemo_api_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamespacesController : ControllerBase
    {
        

        // GET: api/Namespaces
        [HttpGet]
        public IActionResult Get()
        {
            var client = library.Base.getClient();
            var namespaces = client.ListNamespace();
            return Ok(namespaces.Items);
        }

        // GET: api/Namespaces/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Namespaces
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Namespaces/5
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
