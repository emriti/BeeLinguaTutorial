using BeeLinguaTutorial.DAL.Models;
using Microsoft.Azure.Documents.Client;
using Nexus.Base.CosmosDBRepository;
using System;

namespace BeeLinguaTutorial.DAL.Repository
{
    public class Repositories
    {
        private static readonly string _eventGridEndPoint = Environment.GetEnvironmentVariable("eventGridEndPoint");
        private static readonly string _eventGridKey = Environment.GetEnvironmentVariable("eventGridEndKey");

        public class ClassRepository: DocumentDBRepository<Class>
        {
            public ClassRepository(DocumentClient client): 
                base("Course", client, partitionProperties: "ClassCode", 
                    eventGridEndPoint: _eventGridEndPoint, eventGridKey: _eventGridKey) { }
        }
    }
}
