using CourseSignUp.Api.Lecturers;
using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Domain.Interfaces.Service;

namespace CourseSignUp.Service.Service
{
    public class LecturerService : ILecturerService
    {
        private ILecturerRepository _lecturerRepository;
        public LecturerService(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }
        public void CreateLecturer(CreateLecturerDto createLecturerDto)
        {
            _lecturerRepository.CreateLecturer(createLecturerDto);
        }
    }
}
