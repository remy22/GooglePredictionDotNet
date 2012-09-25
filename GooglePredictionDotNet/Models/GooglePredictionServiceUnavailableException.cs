using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GooglePredictionDotNet.Models
{
    public class GooglePredictionServiceUnavailableException : Exception
    {
        public GooglePredictionServiceUnavailableException()
        {

        }

        public GooglePredictionServiceUnavailableException(string message)
            : base(message)
        {

        }
    }
}
