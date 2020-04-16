using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexusProductAPI.App_Class
{
    public static class CommonUtilites
    {
        public static T GetData<T>(this object obj)
        {
            Type returnType = typeof(Newtonsoft.Json.Linq.JToken);
            Type sourceType = obj.GetType();
            System.Reflection.PropertyInfo propertyInfo = sourceType.GetProperty("First", returnType);
            Newtonsoft.Json.Linq.JToken data1 = (Newtonsoft.Json.Linq.JToken)propertyInfo.GetValue(obj, null);
            T data = (T)Newtonsoft.Json.JsonConvert.DeserializeObject(data1.First().ToString(), typeof(T));
            return data;
        }

        public static string GetOperation(this object obj)
        {
            Type returnType = typeof(Newtonsoft.Json.Linq.JToken);
            Type sourceType = obj.GetType();
            System.Reflection.PropertyInfo propertyInfo = sourceType.GetProperty("Last", returnType);
            Newtonsoft.Json.Linq.JToken data1 = (Newtonsoft.Json.Linq.JToken)propertyInfo.GetValue(obj, null);
            return data1.First().ToString();
        }
    }
}