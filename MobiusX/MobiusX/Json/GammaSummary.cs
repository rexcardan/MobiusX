using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class GammaSummary
    {
        [JsonProperty("criteria")]
        public GammaCriteria Criteria { get; set; }
        [JsonProperty("passingRate")]
        public NamedDouble PassingRate { get; set; }

        public override string ToString()
        {
            return string.Format("{0:P3} - {1:P1}/{2:N1}mm", (double)PassingRate.Value, Criteria.Dose.Value, Criteria.MaxDTA_mm.Value);
        }
    }
}
