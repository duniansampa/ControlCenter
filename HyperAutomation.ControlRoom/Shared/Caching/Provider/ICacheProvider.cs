using System;

namespace HyperAutomation.ControlRoom.Shared.Caching.Provider
{
    public interface ICacheProvider
    {
        object Get(
            string key);

        void Insert(
            string key, 
            object value, 
            DateTime absoluteExpiration, 
            TimeSpan slidingExpiration);

        object Remove(
            string key);

        bool IsCacheNull { get; }
    }
}
