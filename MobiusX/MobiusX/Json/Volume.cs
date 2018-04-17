using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobiusX.Json
{
    public class Volume
    {
        [JsonProperty("units")]
        public string Units { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
