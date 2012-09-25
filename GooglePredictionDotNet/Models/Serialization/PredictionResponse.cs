using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GooglePredictionDotNet.Models.Serialization
{
    [DataContract]
    public class PredictionResponse
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "selfLink")]
        public string SelfLink { get; set; }

        [DataMember(Name="outputValue")]
        public decimal OutputValue { get; set; }

        [DataMember(Name = "outputLabel")]
        public string OutputLabel { get; set; }

        [DataMember(Name = "outputMulti")]
        public IEnumerable<CategoricalResult> OutputMulti { get; set; }
    }

    [DataContract]
    public class CategoricalResult
    {
        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "score")]
        public decimal Score { get; set; }
    }
}
