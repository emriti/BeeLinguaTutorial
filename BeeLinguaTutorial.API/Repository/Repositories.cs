using Microsoft.Azure.Documents.Client;
using Nexus.Base.CosmosDBRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeLinguaTutorial.API.Repository
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
