using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class PlanInfo
    {
        [JsonProperty("RTGeneralPlan.PlanIntent")]
        public string PlanIntent { get; set; }

        [JsonProperty("RTGeneralPlan.RTPlanLabel")]
        public string RTPlanLabel { get; set; }

        [JsonProperty("RTGeneralPlan.RTPlanName")]
        public string RTPlanName { get; set; }

        [JsonProperty("RTGeneralPlan.RTPlanDate")]
        public string RTPlanDate { get; set; }
    }
}
