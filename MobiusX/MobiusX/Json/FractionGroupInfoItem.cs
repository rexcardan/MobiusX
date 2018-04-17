using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class FractionGroupInfoItem
    {
        [JsonProperty("NumberofFractionsPlanned")]
        public int NumberofFractionsPlanned { get; set; }

        [JsonProperty("TreatmentMachineName")]
        public string TreatmentMachineName { get; set; }

        [JsonProperty("matchedMachineName_list")]
        public string[] MatchedMachines { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        public List<FxBeamInfoItem> BeamInfos { get; set; } = new List<FxBeamInfoItem>();
    }
}
