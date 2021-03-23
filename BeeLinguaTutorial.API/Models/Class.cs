using Newtonsoft.Json;
using Nexus.Base.CosmosDBRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeLinguaTutorial.API
{
    public class Class: ModelBase
    {
        [JsonProperty("classCode")]
        public string ClassCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
