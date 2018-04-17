using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class PlanDICOM
    {
        [JsonProperty("md5")]
        public string MD5 { get; set; }
        [JsonProperty("sopinst")]
        public string SOPInstanceUID { get; set; }
    }
}
