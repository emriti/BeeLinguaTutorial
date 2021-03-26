using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BeeLinguaTutorial.DAL.Models;
using BeeLinguaTutorial.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BeeLinguaTutorial.API
{
    public static class Function1
    {
        [FunctionName("GetAllClass")]
        public static async Task<IActionResult> GetAllClass(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [CosmosDB(ConnectionStringSetting = "cosmos-bl-tutorial-serverless")] DocumentClient documentClient,
            ILogger log)
        {
            var query = new SqlQuerySpec("SELECT * FROM c");
            var pk = new PartitionKey("Class");
            var options = new FeedOptions() { PartitionKey = pk };
            var data = documentClient.CreateDocumentQuery(UriFactory.CreateDocumentCollectionUri("Course", "Class"), query, options);
            return new OkObjectResult(data);
        }

        [FunctionName("GetClassById")]
        public static IActionResult GetClassById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Course/{id}")] HttpRequest req,
            [CosmosDB(
                databaseName: "Course",
                collectionName: "Class",
                ConnectionStringSetting = "cosmos-bl-tutorial-serverless",
                Id = "{id}",
                PartitionKey = "Class")] Class class1,
            ILogger log)
        {
            return new OkObjectResult(class1);
        }

        [FunctionName("GetClassByIdNexus")]
        public static async Task<IActionResult> GetClassByIdNexus(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "CourseNexus/{id}/{kode}")] HttpRequest req,
            [CosmosDB(ConnectionStringSetting = "cosmos-bl-tutorial-serverless")] DocumentClient documentClient,
            string id,
            string kode,
            ILogger log)
        {
            using var classRep = new Repositories.ClassRepository(documentClient);
            var data = await classRep.GetAsync(predicate: p => p.Id == id, partitionKeys: new Dictionary<string, string> { { "ClassCode", kode } });
            return new OkObjectResult(data);
        }

        [FunctionName("CreateDataNexus")]
        public static async Task<IActionResult> CreateDataNexus(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "CourseNexus/create")] HttpRequest req,
            [CosmosDB(ConnectionStringSetting = "cosmos-bl-tutorial-serverless")] DocumentClient documentClient,
            ILogger log)
        {
            var class1 = new Class() { ClassCode = "abc1", Description = "xyz2" };

            using var classRep = new Repositories.ClassRepository(documentClient);
            var data = await classRep.CreateAsync(class1);
            return new OkObjectResult(data);
        }

    }
}

