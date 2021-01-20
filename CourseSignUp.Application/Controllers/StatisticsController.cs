using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Api.Statistics
{
    [ApiController, Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService,
                                    ICacheService cacheService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                bool mock = true; // change this to false to remove the mock

                if (!mock)
                {
                    var statistics = _statisticsService.GetCourseStatistics();

                    return Ok(statistics);
                }
                else
                {
                    List<CourseStatistics> statistics = new List<CourseStatistics>();
                    statistics.Add(new CourseStatistics()
                    {
                        Id = "123",
                        Name = "Course Name",
                        AverageAge = 40,
                        MinimumAge = 15,
                        MaximumAge = 60
                    });

                    return Ok(statistics);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}