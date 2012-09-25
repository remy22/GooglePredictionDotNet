using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GooglePredictionDotNet.Services
{
    public interface IWebService
    {
        /// <summary>
        /// GET a request
        /// </summary>
        /// <typeparam name="TResponse">The response type</typeparam>
        /// <returns>The response</returns>
        TResponse Get<TResponse>() where TResponse : class;

        /// <summary>
        /// POST a request to the web service
        /// </summary>
        /// <typeparam name="TRequest">The type of data to serialize for the request</typeparam>
        /// <typeparam name="TResponse">The type of response for deserializing</typeparam>
        /// <param name="data">The data to serialize and send</param>
        /// <returns>The response</returns>
        TResponse Post<TRequest, TResponse>(TRequest data) where TRequest : class
                                                           where TResponse : class;

    }
}
