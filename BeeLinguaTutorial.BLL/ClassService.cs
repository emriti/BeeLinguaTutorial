using BeeLinguaTutorial.DAL.Models;
using Nexus.Base.CosmosDBRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeeLinguaTutorial.BLL
{
    public class ClassService
    {
        private readonly IDocumentDBRepository<Class> _repository;
        public ClassService(IDocumentDBRepository<Class> repository)
        {
            if (this._repository == null)
            {
                this._repository = repository;
            }
        }

        public async Task<Class> GetClassById(string id, Dictionary<string, string> pk)
        {
            return await _repository.GetByIdAsync(id, pk);
        }
    }
}
