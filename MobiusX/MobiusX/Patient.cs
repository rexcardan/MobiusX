using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobiusX
{
    public class Patient
    {
        [JsonProperty("plans")]
        public Plan[] Plans { get; set; }

        [JsonProperty("patientId")]
        public string PatientId { get; set; }

        [JsonProperty("patientName")]
        public string PatientName { get; set; }
    }

}
