using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace CourseSignUp.Service.Service
{
    public class StatisticsService : IStatisticsService
    {
        private IStatisticsRepository _statisticsRepository;
        ICacheService _cacheService;

        public StatisticsService(IStatisticsRepository statisticsRepository, ICacheService cacheService)
        {
            _statisticsRepository = statisticsRepository;
            _cacheService = cacheService;
        }
        public IEnumerable<CourseStatistics> GetCourseStatistics()
        {
            string key = "CourseStatistics";

            var statistics = _cacheService.GetCourseStatistics<IEnumerable<CourseStatistics>>(key);

            if (statistics == null)
            {
                statistics = _statisticsRepository.GetCourseStatistics();

                _cacheService.SetCourseStatistics(key, statistics);
            }
            return statistics;
        }
    }
}
