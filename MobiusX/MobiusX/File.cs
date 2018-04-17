using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobiusX
{
    public class File
    {
        public Plan Plan { get; internal set; }

        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("stub")]
        public bool Stub { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("gzip")]
        public bool Gzip { get; set; }

        [JsonProperty("revpos")]
        public int RevPos { get; set; }

        [JsonProperty("digest")]
        public string Digest { get; set; }
    }
}
