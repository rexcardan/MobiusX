using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobiusX;

public class Plan
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("request_cid")]
    public string RequestCid { get; set; }

    [JsonProperty("notes")]
    public string Notes { get; set; }

    [JsonProperty("results")]
    public Results Results { get; set; }

    [JsonProperty("reason")]
    public object Reason { get; set; }

    [JsonProperty("created_timestamp")]
    public double CreatedTimestamp { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    public DateTime CreatedDateTime
    {
        get
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(CreatedTimestamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
