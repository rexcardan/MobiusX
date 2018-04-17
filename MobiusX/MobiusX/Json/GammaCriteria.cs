using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobiusX.Json
{
    public class GammaCriteria
    {
        [JsonProperty("dose")]
        public NamedDouble Dose { get; set; }
        [JsonProperty("maxDTA_mm")]
        public NamedDouble MaxDTA_mm { get; set; }
    }
}
