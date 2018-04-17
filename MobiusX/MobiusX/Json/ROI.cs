using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiusX.Json
{
    public class ROI
    {
        public int ROINumber { get; set; }

        public string ROIName { get; set; }

        [JsonProperty("volume")]
        public Volume Volume { get; set; }

        public static ROI FromToken(Newtonsoft.Json.Linq.JToken roi)
        {
            var ob = roi.Last;
            var obString = ob.ToString();
            var convert = JsonConvert.DeserializeObject<ROI>(obString);
            return convert;
        }

        public DoseComparison Coverage90 { get; set; }
        public DoseComparison MeanDose { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1},  {2}", ROINumber, ROIName, MeanDose);
        }
    }
}

