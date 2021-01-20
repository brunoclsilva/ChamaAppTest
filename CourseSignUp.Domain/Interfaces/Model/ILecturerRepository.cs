using CourseSignUp.Api.Lecturers;

namespace CourseSignUp.Domain.Interfaces
{
    public interface ILecturerRepository
    {
        public void CreateLecturer(CreateLecturerDto createLecturerDto);
    }
}
