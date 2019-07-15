using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nemo_api_service.Models
{
    public class Enviroment
    {

        public string Name { get; set; }

        public string Status { get; set; }

        public string CreateDate {get;set;}

        public string URL { get; set; }

        public string Port { get; set; }

        public string ServiceName {get;set;}

        public string ServiceIP {get;set;}

        public string ServicePort {get;set;}

        public string WorkloadName {get;set;}

        public string WorkloadCount {get;set;}



    }
}
