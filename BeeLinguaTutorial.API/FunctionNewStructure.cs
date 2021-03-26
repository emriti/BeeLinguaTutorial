using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BeeLinguaTutorial.BLL;
using BeeLinguaTutorial.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nexus.Base.CosmosDBRepository;
using static BeeLinguaTutorial.DAL.Repository.Repositories;

namespace BeeLinguaTutorial.API
{
    public static class FunctionNewStructure
    {
        [FunctionName("GetClassByIdNew")]
        public static async Task<IActionResult> GetClassByIdNew(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "coursenew/{id}")] HttpRequest req,
            [CosmosDB(ConnectionStringSetting = "cosmos-bl-tutorial-serverless")] DocumentClient client,
            string id,
            ILogger log)
        {
            ClassService classService = new ClassService(new ClassRepository(client));
            var data = await classService.GetClassById(id, new Dictionary<string, string> { { "ClassCode", "abc1" } });
            return new OkObjectResult(data);
        }
    }
}

