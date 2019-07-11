using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
namespace nemo_api_service.library
{
    public static class Base {
        public static IKubernetes getClient()
        {            
            var config = KubernetesClientConfiguration.BuildConfigFromConfigFile("wwwroot/config.txt");
            var client = new Kubernetes(config);
            return client;
        }
    }

}
