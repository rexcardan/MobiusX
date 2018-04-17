using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class BeamDoseInfoItem
    {
        [JsonProperty("computedDose")]
        public NamedDouble ComputedDose { get; set; }
        [JsonProperty("computedMu")]
        public NamedDouble ComputedMu { get; set; }
        [JsonProperty("diff")]
        public NamedDouble Diff { get; set; }
        [JsonProperty("externalDose")]
        public NamedDouble ExternalTPSDose { get; set; }

        public override string ToString()
        {
            return string.Format("{0:P2} | TPS = {1:F2}, M3D = {2:F2}", Diff.Value, ExternalTPSDose.Value, ComputedDose.Value);

        }
    }
}
