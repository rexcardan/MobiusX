//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MobiusX.Json;

//namespace MobiusX
//{
//    public static class MobiusDeserializer
//    {
//        public static Data DeserializeData(Dictionary<string, object> data)
//        {
//            try
//            {
//                var dataString = JsonConvert.SerializeObject(data);
//                var template = new
//                {
//                    targetCoverage_result = new { roi_num2targetCoverage_dict = new Dictionary<int, dynamic>() },
//                    roiInfo_data = new
//                    {
//                        roi_num2basic_dict = new Dictionary<int, Dictionary<string, dynamic>>()
//                    },
//                    gammaPerRoi_info = new { gamma_roi2info_dict = new Dictionary<int, Dictionary<string, dynamic>>() },
//                    gamma_result = new
//                    {
//                        criteria = new
//                        {
//                            dose = new
//                            {
//                                display_str = "",
//                                value = 0.0
//                            },
//                            maxDTA_mm = new
//                            {
//                                display_str = "",
//                                value = 0.0
//                            }
//                        },
//                        display_str = "",
//                        histogram = new
//                        {
//                            histCount_list = new int[0],
//                            histEdge_list = new double[0]
//                        },
//                        passingRate = new
//                        {
//                            display_str = "",
//                            result = "",
//                            value = 0.0
//                        },
//                        result = "",
//                        thresholdDose = new
//                        {
//                            display_str = "",
//                            value = 0.0
//                        },
//                        voxels = new
//                        {
//                            computed = new
//                            {
//                                display_str = "",
//                                value = new double[0]
//                            },
//                            external = new
//                            {
//                                display_str = "",
//                                value = new double[0]
//                            }
//                        }
//                    },
//                    gamma_summary = new
//                    {
//                        display_str = "",
//                        passingRate = new
//                        {
//                            display_str = "",
//                            result = "",
//                            value = 0.0
//                        },
//                        result = ""
//                    },
//                    beamDose_info = new Dictionary<string, Dictionary<string, BeamDoseInfoItem>>(),
//                    beam_info = new {beam_num2info_dict = new Dictionary<string, BeamInfoItem>()}
//                };

//                var allData = JsonConvert.DeserializeAnonymousType(dataString, template);

//                List<ROI> rois = new List<ROI>();
//                foreach (var roi in allData.roiInfo_data.roi_num2basic_dict)
//                {
//                    ROI r = new ROI();
//                    r.ROINumber = roi.Key;
//                    r.ROIName = roi.Value["ROIName"].ToString();
//                    r.VolumeCC = (double)roi.Value["volume"].value;
//                    if (allData.targetCoverage_result != null)
//                    {
//                        var mean = JsonConvert.SerializeObject(allData.targetCoverage_result.roi_num2targetCoverage_dict[roi.Key].mean_dose);
//                        r.MeanDose = JsonConvert.DeserializeObject<DoseComparison>(mean);
//                        var _90pct = JsonConvert.SerializeObject(allData.targetCoverage_result.roi_num2targetCoverage_dict[roi.Key].coverage_90pct);
//                        r._90PCTCoverage = JsonConvert.DeserializeObject<DoseComparison>(_90pct);
//                    }

//                    r._3DGamma = (double)allData.gammaPerRoi_info.gamma_roi2info_dict[roi.Key]["gamma"].value;
//                    rois.Add(r);
//                }

//                List<BeamDose> bds = new List<BeamDose>();
//                foreach (var beamSet in allData.beamDose_info)
//                {
//                    var bd = new BeamDose();
//                    foreach (var beam in allData.beamDose_info[beamSet.Key])
//                    {
//                        bd.Id = beam.Key;
//                        var beamInfo = allData.beam_info.beam_num2info_dict[bd.Id];
//                        bd.Name = beamInfo.BeamName;
//                        bd.ComputedDose = beam.Value.computedDose.value;
//                        bd.ComputedMU = beam.Value.computedMu.value;
//                        bd.TPSDose = beam.Value.externalDose.value;
//                        bds.Add(bd);
//                    }
//                }
//                var gamma = new GammaSummary();
//                gamma.DoseCriteria = allData.gamma_result.criteria.dose.value;
//                gamma.DistanceCriteria = allData.gamma_result.criteria.maxDTA_mm.value;
//                gamma.ThresholdDose = allData.gamma_result.thresholdDose.value;
//                gamma.Value = allData.gamma_result.passingRate.value;

//                var solidData = new Data();
//                solidData.GammaSummary = gamma;
//                solidData.ROIs = rois;
//                solidData.BeamDoses = bds;
//                return solidData;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                return null;
//            }

//        }
//    }
//}
