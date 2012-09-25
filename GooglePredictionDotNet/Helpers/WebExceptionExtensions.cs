using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using GooglePredictionDotNet.Models;

namespace GooglePredictionDotNet.Helpers
{
    public static class WebExceptionExtensions
    {
        public static void CheckAndThrowAuthenticationException(this WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {
                var response = ex.Response as HttpWebResponse;
                if (response != null)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        throw new GooglePredictionAuthException();

                    if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                        throw new GooglePredictionServiceUnavailableException();
                }
            }
        }
    }
}
