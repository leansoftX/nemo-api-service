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
        private readonly IKubernetes _client = library.Base.getClient();

       
        // GET: api/Namespaces
        [HttpGet]
        public IActionResult Get()
        {
          
            var namespaces = _client.ListNamespace();
            return Ok(namespaces.Items);
        }

        // GET: api/Namespaces/5
        [HttpGet("{name}", Name = "Get")]
        public string Get(string name)
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
