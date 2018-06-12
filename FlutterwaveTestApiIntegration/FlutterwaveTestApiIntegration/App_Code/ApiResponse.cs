using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace FlutterwaveTestApiIntegration.App_Code
{
    public class ApiResponse
    {

        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("data")]
        public DataClass data { get; set; }

    }
}