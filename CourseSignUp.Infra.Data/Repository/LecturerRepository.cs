using CourseSignUp.Api.Lecturers;
using CourseSignUp.Domain.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;

namespace CourseSignUp.Infra.Data.Repository
{
    public class LecturerRepository : ILecturerRepository
    {
        private IConfiguration _configuration;
        public LecturerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void CreateLecturer(CreateLecturerDto createLecturerDto)
        {
            var connectionString = _configuration.GetConnectionString("CosmosDB");
            var client = new CosmosClientBuilder(connectionString)
                                .WithSerializerOptions(new CosmosSerializationOptions
                                {
                                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                                })
                                .Build();

            var createLecturerContainer = client.GetContainer("TestDatabase", "Lecturer");

            var lecturer = new CreateLecturerDto
            {
                Name = createLecturerDto.Name
            };

            await createLecturerContainer.CreateItemAsync(lecturer);
        }
    }
}
