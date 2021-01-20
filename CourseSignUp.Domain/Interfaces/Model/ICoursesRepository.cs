using CourseSignUp.Api.Courses;

namespace CourseSignUp.Domain.Interfaces
{
    public interface ICoursesRepository
    {
        public CourseDto GetCourses(string id);
        public void CreateCourse(CreateCourseDto createCourse);
    }
}
