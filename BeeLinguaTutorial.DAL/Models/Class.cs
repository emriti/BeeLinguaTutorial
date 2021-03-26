using Newtonsoft.Json;
using Nexus.Base.CosmosDBRepository;

namespace BeeLinguaTutorial.DAL.Models
{
    public class Class: ModelBase
    {
        [JsonProperty("classCode")]
        public string ClassCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
