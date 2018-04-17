using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class BeamInfoItem
    {
        public string BeamName { get; set; }

        [JsonProperty("applicator")]
        public NamedString Applicator { get; set; }

        [JsonProperty("collimatorAngle")]
        public Named CollimatorAngle { get; set; }

        [JsonProperty("collision")]
        public NamedDouble Collision { get; set; }

        [JsonProperty("couchAngle")]
        public Named CouchAngle { get; set; }

        [JsonProperty("deliverable")]
        public Named IsDeliverable { get; set; }

        [JsonProperty("jaws")]
        public Jaws Jaws { get; set; }

        [JsonProperty("numControlPoints")]
        public NamedDouble NumControlPoints { get; set; }

        [JsonProperty("numBeamOnSegments")]
        public NamedDouble NumBeamOnSegments { get; set; }

        [JsonProperty("patientSetupPosition_str")]
        public string PatientSetupPosition { get; set; }

        [JsonProperty("patientSetupTechnique_str")]
        public string PatientSetupTechnique { get; set; }

        [JsonProperty("rotationType_str")]
        public string RotationType { get; set; }

        [JsonProperty("mlcType_str")]
        public string MlcType { get; set; }

        [JsonProperty("tdsInfo_dict")]
        public MachineInfo MachineInfo { get; set; }

        public string Name { get; set; }

        public BeamDoseInfoItem DoseInfo { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1},  {2}", Name, BeamName, DoseInfo);
        }
    }
}
