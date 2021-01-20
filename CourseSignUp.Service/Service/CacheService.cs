using CourseSignUp.Domain.Interfaces.Service;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CourseSignUp.Service.Service
{
    public class CacheService : ICacheService
    {
        private IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public T GetCourseStatistics<T>(string key)
        {
            var serializedObject = _cache.GetString(key);

            return JsonConvert.DeserializeObject<T>(serializedObject);
        }

        public void SetCourseStatistics<T>(string key, T value)
        {
            var serializedObject = JsonConvert.SerializeObject(value);

            var expiration = new DistributedCacheEntryOptions();

            _cache.SetString(key, serializedObject, expiration);
        }
    }
}
