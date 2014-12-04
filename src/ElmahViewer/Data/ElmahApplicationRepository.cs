using System;
using System.Collections.Generic;
using System.Linq;

namespace ElmahViewer.Data
{
    public class ElmahApplicationRepository : IElmahApplicationRepository
    {
        private readonly ICache _cache;
        private const string CacheKey = "appNames";

        public ElmahApplicationRepository(ICache cache)
        {
            _cache = cache;
        }

        public IEnumerable<string> GetAllApplicationNames()
        {
            var appNames = _cache.Get<IEnumerable<string>>(CacheKey);
            if(appNames != null && appNames.Any())
            {
                return appNames;
            }
            var result = Massive.DB.Current.Query("Select Distinct [Application] FROM ELMAH_Error");
            var expandos = result.Cast<IDictionary<string, object>>();
            appNames = expandos.SelectMany(x => x.Values).Cast<string>().OrderBy(x=>x);
            _cache.Insert(CacheKey, appNames, DateTime.Now.AddDays(1));
            return appNames;
        }
    }
}