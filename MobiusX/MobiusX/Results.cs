using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobiusX
{
    public class Results
    {
        [JsonProperty("Target Coverage")]
        public string TargetCoverage { get; set; }

        [JsonProperty("None")]
        public string None { get; set; }

        [JsonProperty("Gamma")]
        public string Gamma { get; set; }

        [JsonProperty("DVH Limit")]
        public string DVHLimit { get; set; }
    }
}
