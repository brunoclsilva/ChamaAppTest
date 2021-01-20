using System;
using System.Threading.Tasks;
using CourseSignUp.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignUp.Api.Lecturers
{
    [ApiController, Route("[controller]")]
    public class LecturersController : ControllerBase
    {
        private ILecturerService _lecturerService;


        public LecturersController(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Post([FromBody]CreateLecturerDto createLecturerDto)
        {
            try
            {
                bool mock = true; // change this to false to remove the mock

                if (!mock)
                {
                    _lecturerService.CreateLecturer(createLecturerDto);

                    return Ok();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}