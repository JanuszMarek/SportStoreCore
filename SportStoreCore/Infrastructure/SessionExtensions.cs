using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreCore.Infrastructure
{
    public static class SessionExtensions
    {
        /*
        The HttpContext.Session  property returns an object that implements the ISession interface, 
        which is the type on which I defined the SetJson method, which accepts arguments that specify 
        a key and an object that will be added to the session state. The extension method serializes 
        the object and adds it to the session state using the underlying functionality provided by
        the ISession interface.
        */

        public static void SetJson(this ISession session, string key, object value )
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
