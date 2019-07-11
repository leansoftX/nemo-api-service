using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using k8s.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nemo_api_service.Models;

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
        public IActionResult GetByName(string name)
        {
            var ns = _client.ReadNamespace(name);
            var services = _client.ListNamespacedService(ns.Metadata.Name);
            var loadBalancerService = new V1Service();
            foreach (var service in services.Items)
            {
                if (service.Spec.Type == "LoadBalancer")
                {
                    loadBalancerService = service;
                }
            }
            var enviroment = new Enviroment
            {
                Name = ns.Metadata.Name,
                Status = ns.Status.Phase,
                URL = loadBalancerService.Status.LoadBalancer.Ingress[0].Ip
            };

            return Ok(enviroment);

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
