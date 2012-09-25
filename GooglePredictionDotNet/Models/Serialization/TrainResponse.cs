using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GooglePredictionDotNet.Models.Serialization
{
    [DataContract]
    public class TrainResponse
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "selfLink")]
        public string SelfLink { get; set; }
    }
}
