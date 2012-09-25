using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GooglePredictionDotNet.Models
{
    [DataContract]
    public class TrainRequest
    {
        [DataMember(Name="id")]
        public string Id { get; set; }
    }
}
