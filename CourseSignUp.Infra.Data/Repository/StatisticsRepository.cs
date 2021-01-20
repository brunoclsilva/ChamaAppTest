using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CourseSignUp.Infra.Data.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private IConfiguration _configuration;
        public StatisticsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<CourseStatistics> GetCourseStatistics()
        {
            using (var con = new SqlConnection(_configuration.GetConnectionString("SQLConnection")))
            {
                try
                {
                    con.Open();
                    var query = $@"select C.id as Id, 
                                                C.name as Name,
                                                MIN((CONVERT(int,CONVERT(char(8),GETDATE(),112))-CONVERT(char(8),S.dateOfBirth,112))/10000) as MinimumAge,
                                                MAX((CONVERT(int,CONVERT(char(8),GETDATE(),112))-CONVERT(char(8),S.dateOfBirth,112))/10000) as MaximumAge,
                                                AVG((CONVERT(int,CONVERT(char(8),GETDATE(),112))-CONVERT(char(8),S.dateOfBirth,112))/10000) as AverageAge
                                               from Course C
                                               join Course_Student CS on CS.courseId = C.id
                                               join Student S on S.id = CS.studentId
                                               group by C.id, C.name";

                    var statistics = con.Query<CourseStatistics>(query);

                    return statistics;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
