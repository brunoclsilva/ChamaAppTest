using CourseSignUp.Domain.Entities;
using System.Collections.Generic;

namespace CourseSignUp.Domain.Interfaces.Service
{
    public interface ICacheService
    {
        public T GetCourseStatistics<T>(string key);
        public void SetCourseStatistics<T>(string key, T value);
    }
}
