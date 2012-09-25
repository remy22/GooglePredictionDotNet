using GooglePredictionDotNet.Models;
using GooglePredictionDotNet.Models.Serialization;

namespace GooglePredictionDotNet.Services
{
    public interface IGooglePredictionClient
    {
        /// <summary>
        /// Train the prediction API
        /// </summary>
        /// <returns>True if the data was successfully trained</returns>
        bool Train();

        /// <summary>
        /// Get the current status of training
        /// </summary>
        /// <returns>Prediction API can return Done, Running, or Error </returns>
        TrainingStatusResponse GetTrainingStatus();

        /// <summary>
        /// Make a prediction
        /// </summary>
        /// <param name="features">The features for this prediction</param>
        /// <returns>The prediction result</returns>
        PredictionResponse Predict(params object[] features);

        /// <summary>
        /// Path to the model data (bucket/data.csv)
        /// </summary>
        string ModelPath { get; set; }
    }
}
