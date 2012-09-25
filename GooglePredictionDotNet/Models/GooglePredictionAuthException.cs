using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GooglePredictionDotNet.Models
{
    public class GooglePredictionAuthException : Exception
    {
        public GooglePredictionAuthException()
        {

        }

        public GooglePredictionAuthException(string message)
            :base(message)
        {
            
        }
    }
}
