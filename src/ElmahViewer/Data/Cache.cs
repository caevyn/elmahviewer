using System;
using System.Web;

namespace ElmahViewer.Data
{
    public class Cache : ICache
    {
        public object Get(string key)
        {
            return HttpContext.Current.Cache.Get(key);
        }

        public T Get<T>(string key) where T : class
        {
            return (T)HttpContext.Current.Cache.Get(key);
        }

        public void Insert(string key, object toCache)
        {
            HttpContext.Current.Cache.Insert(key, toCache);
        }

        public void Insert(string key, object toCache, DateTime expires)
        {
            HttpContext.Current.Cache.Insert(key, toCache, null, expires, TimeSpan.Zero);
        }
    }
}