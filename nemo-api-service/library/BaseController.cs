using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace nemo_api_service.library
{
    public class BaseController:Controller
    {
        public IKubernetes _client;
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            var _httpContextAccessor = httpContextAccessor;
            var header = _httpContextAccessor.HttpContext.Request.Headers;
            
            byte[] kubeConfigContentByte= Convert.FromBase64String(header["kubeConfig"]);
            var kubeConfigContent = System.Text.Encoding.Default.GetString(kubeConfigContentByte);
            Stream kubeConfig = Utilities.GenerateStreamFromString(kubeConfigContent);
            var config = KubernetesClientConfiguration.BuildConfigFromConfigFile(kubeConfig);
            _client = new Kubernetes(config);
        }
        
    }
}
