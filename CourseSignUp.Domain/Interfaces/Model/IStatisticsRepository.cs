using CourseSignUp.Domain.Entities;
using System.Collections.Generic;

namespace CourseSignUp.Domain.Interfaces
{
    public interface IStatisticsRepository
    {
        public IEnumerable<CourseStatistics> GetCourseStatistics();
    }
}
