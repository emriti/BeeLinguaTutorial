using BeeLinguaTutorial.DAL.Models;
using Moq;
using Nexus.Base.CosmosDBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BeeLinguaTutorial.BLL.Test
{
    public class ClassServiceTest
    {
        public class GetClassById
        {
            [Theory]
            [InlineData("1")]
            [InlineData("3")]
            public async Task GetDataById_ResultFound(string id)
            {
                // arrange
                var repo = new Mock<IDocumentDBRepository<Class>>();

                IEnumerable<Class> classes = new List<Class>
                {
                    {new Class() { Id = "1", Description = "abcd"} },
                    {new Class() { Id = "2", Description = "xyz0"} }
                };

                var classData = classes.Where(o => o.Id == id).FirstOrDefault();

                repo.Setup(c => c.GetByIdAsync(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, string>>()
                )).Returns(
                    Task.FromResult<Class>(classData)
                );

                var svc = new ClassService(repo.Object);

                // act
                var act = await svc.GetClassById("", null);

                // assert
                Assert.Equal(classData, act);

            }
        }
    }
}
