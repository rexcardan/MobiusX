using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobiusX.Json
{
    public class MachineInfo
    {
        [JsonProperty("coordinates")]
        public string Coordinates { get; set; }
        [JsonProperty("energy2depth10dose_dict")]
        public Dictionary<string, double> EnergyDepthDose10 { get; set; }

        [JsonProperty("institutionName_str")]
        public string Institution { get; set; }

        [JsonProperty("mlc")]
        public string MLC { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("referenceModel")]
        public string ReferenceModel { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }
    }
}
