using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobiusX.Json;

namespace MobiusX
{
    public class Data
    {
        public List<ROI> ROIs { get; set; }
        public GammaSummary GammaSummary { get; set; }
        public List<BeamInfoItem> BeamInfos { get; set; }
        public List<FractionGroupInfoItem> FractionGroupInfos { get; internal set; }
    }
}
