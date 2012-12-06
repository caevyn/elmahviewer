using System;

namespace ElmahViewer.Data
{
    public interface ICache
    {
        object Get(string key);
        T Get<T>(string key) where T : class;
        void Insert(string key, object toCache);
        void Insert(string key, object toCache, DateTime expires);
    }
}