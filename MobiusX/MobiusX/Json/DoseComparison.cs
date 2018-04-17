using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class DoseComparison
    {
        [JsonProperty("external")]
        public NamedDouble TPS { get; set; }

        [JsonProperty("computed")]
        public NamedDouble M3D { get; set; }

        public double PercentDifference
        {
            get
            {
                if (M3D.Value == null || TPS.Value == null) { return double.NaN; }
                else { return 1 - (double)M3D.Value / (double)TPS.Value; }
            }
        }

        public override string ToString()
        {
            return string.Format("{0:P2} | TPS = {1:F2}, M3D = {2:F2}", PercentDifference, TPS.Value, M3D.Value);

        }
    }
}
