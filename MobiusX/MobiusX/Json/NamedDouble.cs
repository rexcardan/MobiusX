using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class NamedDouble : Named
    {
        [JsonProperty("display_str")]
        public string DisplayString { get; set; }

        [JsonProperty("value")]
        public double? Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
