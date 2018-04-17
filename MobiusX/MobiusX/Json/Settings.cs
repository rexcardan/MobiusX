using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class Settings
    {
        [JsonProperty("planInfo_dict")]
        public PlanInfo PlanInfo { get; set; }

        [JsonProperty("plan_dicom")]
        public PlanDICOM DICOMInfo { get; set; }

    }
}
