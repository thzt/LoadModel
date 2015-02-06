using System;
using System.Web.Script.Serialization;

namespace LoadModel.Tools
{
    public static class JsonOperation
    {
        private static readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        public static string Serialize(object obj)
        {
            return serializer.Serialize(obj);
        }

        public static T Deserialize<T>(string json)
        {
            return serializer.Deserialize<T>(json);
        }

        public static object Deserialize(string typeFullName, string json)
        {
            return typeof(JsonOperation)
                .GetMethod("Deserialize", new[] { typeof(string) })
                .MakeGenericMethod(Type.GetType(typeFullName))
                .Invoke(null, new object[] { json });
        }
    }
}