using CourseSignUp.Api.Lecturers;

namespace CourseSignUp.Domain.Interfaces.Service
{
    public interface ILecturerService
    {
        public void CreateLecturer(CreateLecturerDto createLecturerDto);
    }
}
