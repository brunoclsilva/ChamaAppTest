using CourseSignUp.Api.Courses;
using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Domain.Interfaces.Service;

namespace CourseSignUp.Service.Service
{
    public class CourseService : ICoursesService
    {
        private ICoursesRepository _courseRepository;
        public CourseService(ICoursesRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public void CreateCourse(CreateCourseDto createCourse)
        {
            _courseRepository.CreateCourse(createCourse);
        }

        public CourseDto GetCourses(string id)
        {
            return _courseRepository.GetCourses(id);
        }
    }
}
