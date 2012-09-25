using System;
using System.Net;
using System.Reflection;
using System.Text;
using GooglePredictionDotNet.Helpers;

namespace GooglePredictionDotNet.Services
{
    public class WebService : IWebService
    {
        private readonly Uri _url;

        public WebService(string url)
        {
            _url = new Uri(url);

            ForceCanonicalPathAndQuery(_url);
        }

        /// <summary>
        /// GET a request
        /// </summary>
        /// <typeparam name="TResponse">The response type</typeparam>
        /// <returns>The response</returns>
        public TResponse Get<TResponse>() where TResponse : class
        {
            var client = new WebClient();
            
            var response = client.DownloadString(_url);

            var result = JsonHelpers.Deserialize<TResponse>(response);

            return result;
        }

        /// <summary>
        /// POST a request to the web service
        /// </summary>
        /// <typeparam name="TRequest">The type of data to serialize for the request</typeparam>
        /// <typeparam name="TResponse">The type of response for deserializing</typeparam>
        /// <param name="data">The data to serialize and send</param>
        /// <returns>The response</returns>
        public TResponse Post<TRequest, TResponse>(TRequest data)
            where TRequest : class
            where TResponse : class
        {
            var bytes = Encoding.Default.GetBytes(JsonHelpers.Serialize(data));

            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");

                var response = Encoding.Default.GetString(client.UploadData(_url, "POST", bytes));

                var result = JsonHelpers.Deserialize<TResponse>(response);

                return result;
            }

        }

        static void ForceCanonicalPathAndQuery(Uri uri)
        {
            string paq = uri.PathAndQuery; // need to access PathAndQuery
            FieldInfo flagsFieldInfo = typeof(Uri).GetField("m_Flags", BindingFlags.Instance | BindingFlags.NonPublic);
            ulong flags = (ulong)flagsFieldInfo.GetValue(uri);
            flags &= ~((ulong)0x30); // Flags.PathNotCanonical|Flags.QueryNotCanonical
            flagsFieldInfo.SetValue(uri, flags);
        }

    }
}
