using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class FxBeamInfoItem
    {
        [JsonProperty("energy_int")]
        public int EnergyInt { get; set; }

        [JsonProperty("initialCollimatorAngle")]
        public double InitialCollimatorAngle { get; set; }

        [JsonProperty("initialGantryAngle")]
        public double InitialGantryAngle { get; set; }

        [JsonProperty("initialJawXExtents_cm")]
        public double[] InitialJawXExtents_CM { get; set; }

        [JsonProperty("initialJawYExtents_cm")]
        public double[] InitialJawYExtents_CM { get; set; }

        [JsonProperty("initialMlcPositions_cm")]
        public double[,] InitialMlcPositions_CM { get; set; }

        [JsonProperty("isMlcY")]
        public bool IsMlcY { get; set; }

        [JsonProperty("isStaticBeam_bool")]
        public bool IsStaticBeam_bool { get; set; }

        [JsonProperty("mlcBoundaryArray_cm")]
        public double[,] MlcBoundaryArray_CM { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        public double? Meterset { get; set; }

        public int Number { get; internal set; }
    }
}
