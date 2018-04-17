using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobiusX.Json;

namespace MobiusX
{
    public class PlanDetails
    {
        public PlanDetails(string version, Data data)
        {
            Version = version;
            this.Data = data;
        }
        public string Version { get; set; }

        public Data Data { get; set; }
        public Settings Settings { get; private set; }

        public static PlanDetails FromJson(string details)
        {
            var json = JObject.Parse(details);
            var data = new Data();

            var beamInfo = json["data"]["beam_info"]["beam_num2info_dict"];
            data.BeamInfos = new List<BeamInfoItem>();
            if (beamInfo != null)
            {
                foreach (var bd in beamInfo.Children())
                {
                    var num = ((JProperty)bd).Name;
                    var value = ((JProperty)bd).Value;
                    var bdi = JsonConvert.DeserializeObject<BeamInfoItem>(value.ToString());
                    bdi.Name = num;
                    data.BeamInfos.Add(bdi);
                }
            }

            var fxInfo = json["data"]["fractionGroup_info"]["fractionGroup_num2info_dict"];
            data.FractionGroupInfos = new List<FractionGroupInfoItem>();
            if (fxInfo != null)
            {
                foreach (var item in fxInfo)
                {
                    var num = ((JProperty)item).Name;
                    var value = ((JProperty)item).Value;
                    var fgi = JsonConvert.DeserializeObject<FractionGroupInfoItem>(value.ToString());
                    var metersets = value["beam_num2meterset_dict"];
                    var beamInfos = value["beam_num2info_dict"];
                    foreach (var b in beamInfos.Children())
                    {
                        num = ((JProperty)b).Name;
                        value = ((JProperty)b).Value;
                        var bdi = JsonConvert.DeserializeObject<FxBeamInfoItem>(value.ToString());
                        bdi.Number = int.Parse(num);
                        fgi.BeamInfos.Add(bdi);
                    }
                    foreach (var b in metersets.Children())
                    {
                        num = ((JProperty)b).Name;
                        value = ((JProperty)b).Value;
                        var mts = JsonConvert.DeserializeObject<NamedDouble>(value.ToString());
                        var beamMatch = fgi.BeamInfos.FirstOrDefault(bm => bm.Number == int.Parse(num));
                        if (beamMatch != null)
                            beamMatch.Meterset = mts.Value;
                    }
                    data.FractionGroupInfos.Add(fgi);
                }
            }
       
            //Beam Dose Info
            var beamDoseInfo = json["data"]["beamDose_info"];
            if (beamDoseInfo != null && beamDoseInfo.Any())
            {
                foreach (var bd in beamDoseInfo.First().Children().Children())
                {
                    var num = ((JProperty)bd).Name;
                    var match = data.BeamInfos.FirstOrDefault(b => b.Name == num);
                    if (match != null)
                    {
                        var value = ((JProperty)bd).Value;
                        var bdi = JsonConvert.DeserializeObject<BeamDoseInfoItem>(value.ToString());
                        match.DoseInfo = bdi;
                    }
                }
            }


            //ROIs
            var rois = json["data"]["roiInfo_data"]["roi_num2basic_dict"];
            data.ROIs = new List<ROI>();
            if (rois != null)
            {
                foreach (var roi in rois.Children())
                {
                    data.ROIs.Add(ROI.FromToken(roi));
                }
            }


            //ROI Coverage
            var roiCoverage = json["data"]["targetCoverage_result"]["roi_num2targetCoverage_dict"];
            if (roiCoverage != null)
            {
                foreach (var roi in roiCoverage.Children())
                {
                    var num = ((JProperty)roi).Name;
                    var value = ((JProperty)roi).Value;
                    var match = data.ROIs.FirstOrDefault(r => r.ROINumber == int.Parse(num.ToString()));
                    if (match != null)
                    {
                        match.Coverage90 = JsonConvert.DeserializeObject<DoseComparison>(value["coverage_90pct"].ToString());
                        match.MeanDose = JsonConvert.DeserializeObject<DoseComparison>(value["mean_dose"].ToString());
                    }

                }
            }

            var gammaSummary = json["data"]["gamma_summary"];
            data.GammaSummary = JsonConvert.DeserializeObject<GammaSummary>(gammaSummary.ToString());
            var version = (string)((JArray)json["version"]).Children().Last();
            //Construct
            var pdetails = new PlanDetails(version, data);

            var settingsJson = json["settings"];
            var settings = JsonConvert.DeserializeObject<Settings>(settingsJson.ToString());
            pdetails.Settings = settings;
            return pdetails;
        }
    }
}
