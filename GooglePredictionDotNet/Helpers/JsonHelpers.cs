using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GooglePredictionDotNet.Helpers
{
    public class JsonHelpers
    {
        public static string Serialize<T>(T data) where T : class
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(data.GetType());

            using (MemoryStream ms = new MemoryStream())
            {
                ser.WriteObject(ms, data);

                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static T Deserialize<T>(string data) where T : class
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                return (T)ser.ReadObject(ms);
            }
        }
    }
}
