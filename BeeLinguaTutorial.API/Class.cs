using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeLinguaTutorial.API
{
    public class Class
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("classCode")]
        public string ClassCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
