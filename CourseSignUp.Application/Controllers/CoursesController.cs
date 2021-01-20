using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CourseSignUp.Api.Courses
{
    [ApiController, Route("[controller]")]
    public class CoursesController : ControllerBase
    {     
        private ICoursesService _coursesService;
        private IQueueService _queueService;

        private ILogger _logger;

        public CoursesController(ILogger logger,
                                 ICoursesService coursesService,
                                 IQueueService queueService)
        {
            _logger = logger;
            _coursesService = coursesService;
            _queueService = queueService;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                bool mock = true; // change this to false to remove the mock

                if (!mock)
                {
                    var course = _coursesService.GetCourses(id);
                    _logger.LogInformation("Course found" + course.Id);

                    return Ok(course);
                }
                else
                {
                    var course = new CourseDto()
                    {
                        Id = "123456",
                        Capacity = 50,
                        NumberOfStudents = 45
                    };

                    return Ok(course);
                }
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Post([FromBody]CreateCourseDto createCourseDto)
        {
            try
            {
                bool mock = true; // change this to false to remove the mock

                if (!mock)
                {
                    _coursesService.CreateCourse(createCourseDto);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost, Route("sign-up")]
        public async Task<IActionResult> Post([FromBody] SignUpToCourseDto signUpToCourseDto)
        {
            try
            {
                // Here, the obj signUpToCourseDto is sent to Azure ServiceBus and processed by the any worker that notify the user.
                _queueService.SendMessage(JsonConvert.SerializeObject(signUpToCourseDto));
                return Ok("Message sent to queue successfully!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
