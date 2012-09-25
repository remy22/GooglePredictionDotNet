using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GooglePredictionDotNet.Models.Serialization
{
    [DataContract]
    public class PredictionRequest
    {
        [DataMember(Name = "input")]
        public PredictionInput Input { get; set; }
    }

    [DataContract(Name = "input")]
    public class PredictionInput
    {
        [DataMember(Name = "csvInstance")]
        public object[] Features { get; set; }
    }
}
