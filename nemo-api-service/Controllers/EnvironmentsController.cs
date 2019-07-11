using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace nemo_api_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentsController : Controller
    {
        private readonly IKubernetes _client = library.Base.getClient();

        // GET: api/Environments
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("GetByName/{name}")]
        public string GetByName(string name)
        {
            var ns = _client.ReadNamespace(name);
            return ns.Metadata.Name;
        }

        // POST: api/Environments
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Environments/5
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
