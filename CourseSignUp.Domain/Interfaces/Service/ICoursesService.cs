using CourseSignUp.Api.Courses;

namespace CourseSignUp.Domain.Interfaces.Service
{
    public interface ICoursesService
    {
        public CourseDto GetCourses(string id);
        public void CreateCourse(CreateCourseDto createCourse);
    }
}
