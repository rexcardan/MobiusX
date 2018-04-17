using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobiusX.Json;

namespace MobiusX
{
    public class MobiusContext
    {
        private MobiusClient _client;

        /// <summary>
        /// An class which has useful functions for querying the Mobius server
        /// </summary>
        /// <param name="mobiusIpAddress">the ip address of the server (eg. 192.168.1.1) </param>
        /// <param name="username">the registered username in Mobius server</param>
        /// <param name="password">the registered password in Mobius server</param>
        public MobiusContext(string mobiusIpAddress, string username, string password)
        {
            _client = new MobiusClient(mobiusIpAddress);
            _client.LogIn(username, password);
        }

        /// <summary>
        /// Gets the list of patients from Mobius web server
        /// </summary>
        /// <param name="limit">the maxiumum number of patients to take</param>
        /// <returns></returns>
        public List<Patient> GetPatientList(int limit = 100)
        {
            var listString = _client.DownloadString(_client.URI + (object)"/_plan/list?sort=date&descending=1&limit=" + limit);
            var format = new { patients = new List<Patient>() };
            var patientList = JsonConvert.DeserializeAnonymousType(listString, format);
            return patientList.patients;
        }

        public PlanDetails GetPlanCheckDetail(Plan p)
        {
            var details = GetPlanCheckJson(p);
            return PlanDetails.FromJson(details);
        }

        /// <summary>
        /// Retrieves all files related to the input plan
        /// </summary>
        /// <param name="p">the plan with files needed</param>
        /// <returns>a list of file objects</returns>
        public List<File> GetPlanFiles(Plan p)
        {
            var url = string.Format(@"{0}/check/details/{1}/data?format=json", URI, p.RequestCid);
            var listString = _client.DownloadString(url);
            var format = new { version = new string[3], data = new List<File>() };
            var json = JsonConvert.DeserializeAnonymousType(listString, format);
            foreach (var file in json.data)
            {
                file.Plan = p;
            }
            return json.data;
        }

        /// <summary>
        /// Downloads the specified file to the specified location
        /// </summary>
        /// <param name="f">the file object</param>
        /// <param name="path">the path to write the file bytes</param>
        /// <returns></returns>
        public void DownloadFile(File f, string path)
        {
            var directory = System.IO.Path.GetDirectoryName(path);
            path = directory + @"\" + f.FileName;
            var serverPath = string.Format("{0}/check/attachment/{1}/{2}", URI, f.Plan.RequestCid, f.FileName);
            _client.DownloadFile(new Uri(serverPath), path);
        }

        /// <summary>
        /// Downloads the file to a byte array for processing
        /// </summary>
        /// <param name="f">the file object</param>
        /// <returns>a byte array of the file requested</returns>
        public byte[] DownloadFileBytes(File f)
        {
            var serverPath = string.Format("{0}/check/attachment/{1}/{2}", URI, f.Plan.RequestCid, f.FileName);
            return _client.DownloadData(new Uri(serverPath));
        }

        private string GetPlanCheckJson(Plan p)
        {
            return _client.DownloadString(_client.URI + "/check/details/" + p.RequestCid + "?format=json");
        }

        private IEnumerable<ROI> GetROIOverview(Plan p)
        {
            var details = GetPlanCheckDetail(p);
            return null;
        }

        public string URI
        {
            get { return _client.URI; }
        }

    }
}
