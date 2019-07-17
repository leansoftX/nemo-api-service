using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s.Models;
namespace nemo_api_service.Models
{
    public class Enviroment
    {

        public string Name { get; set; }

        public string Status { get; set; }

        public string CreateDate {get;set;}

        public IList<V1Service> Services { get; set; }

        public IList<V1Deployment> Deployments { get; set; }



    }
}
