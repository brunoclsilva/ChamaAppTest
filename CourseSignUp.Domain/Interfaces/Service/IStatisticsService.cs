using CourseSignUp.Domain.Entities;
using System.Collections.Generic;

namespace CourseSignUp.Domain.Interfaces.Service
{
    public interface IStatisticsService
    {
        public IEnumerable<CourseStatistics> GetCourseStatistics();
    }
}
