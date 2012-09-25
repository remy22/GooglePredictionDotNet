using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GooglePredictionDotNet.Models
{
    [DataContract]
    public class TrainingStatusResponse
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "selfLink")]
        public string SelfLink { get; set; }

        [DataMember(Name = "trainingStatus")]
        public string TrainingStatus { get; set; }

        [DataMember(Name = "modelInfo")]
        public ModelInfo ModelInfo { get; set; }
    }

    [DataContract]
    public class ModelInfo
    {
        [DataMember(Name = "modelType")]
        public string ModelType { get; set; }

        [DataMember(Name = "classificationAccuracy")]
        public decimal ClassificationAccuracy { get; set; }

        [DataMember(Name = "meanSquaredError")]
        public decimal MeanSquaredError { get; set; }
    }
}
