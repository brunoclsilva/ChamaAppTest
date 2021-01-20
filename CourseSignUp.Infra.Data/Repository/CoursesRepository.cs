using CourseSignUp.Api.Courses;
using CourseSignUp.Domain.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using System;

namespace CourseSignUp.Infra.Data.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private IConfiguration _configuration;
        public CoursesRepository (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CourseDto GetCourses(string id)
        {
            var connectionString = _configuration.GetConnectionString("CosmosDB");
            var client = new CosmosClientBuilder(connectionString)
                                        .WithSerializerOptions(new CosmosSerializationOptions
                                        {
                                            PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                                        })
                                        .Build();

            var courseContainer = client.GetContainer("TestDatabase", "Course");

            var course = courseContainer.GetItemQueryIterator<CourseDto>("SELECT * FROM Course WHERE c.id = " + id);

            throw new NotImplementedException();
        }

        public async void CreateCourse(CreateCourseDto createCourse)
        {
            var connectionString = _configuration.GetConnectionString("CosmosDB");
            var client = new CosmosClientBuilder(connectionString)
                                .WithSerializerOptions(new CosmosSerializationOptions
                                {
                                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                                })
                                .Build();

            var createCourseContainer = client.GetContainer("TestDatabase", "Course");

            var person = new CreateCourseDto
            {
                LecturerId = createCourse.LecturerId,
                Capacity = createCourse.Capacity,
                Name = createCourse.Name
            };

            await createCourseContainer.CreateItemAsync(person);
        }
    }
}
