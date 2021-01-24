using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DietSite.Helpers
{
    public static class SessionHelpers
    {
        public static void StoreObject(this ISession session, string key, object value)
        {
            var json = JsonConvert.SerializeObject(value);
            session.SetString(key, json);
        }
        public static T GetObject<T>(this ISession session, string key)
        {
            try
            {

                var json = session.GetString(key);
                return JsonConvert.DeserializeObject<T>(json);

            }
            catch (Exception ex)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
    }
}
