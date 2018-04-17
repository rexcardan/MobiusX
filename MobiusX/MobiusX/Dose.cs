using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX
{
    public class Dose
    {
        [JsonProperty("display_str")]
        public string DisplayString { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
