using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pendingProds.Models
{
    public class Attributes
    {
        [JsonProperty("payroll-id")]
        public int payroll_id { get; set; }
        [JsonProperty("full-name")]
        public string full_name { get; set; }
        [JsonProperty("position-id")]
        public int position_id { get; set; }
        [JsonProperty("position-description-es")]
        public string position_description_es { get; set; }
        [JsonProperty("department-id")]
        public int department_id { get; set; }
        [JsonProperty("department-description-es")]
        public string department_description_es { get; set; }
        [JsonProperty("area-id")]
        public int area_id { get; set; }
        [JsonProperty("area-description-es")]
        public string area_description_es { get; set; }
        [JsonProperty("supervisor-code")]
        public string supervisor_code { get; set; }
        [JsonProperty("supervisor-name")]
        public string supervisor_name { get; set; }
    }
}