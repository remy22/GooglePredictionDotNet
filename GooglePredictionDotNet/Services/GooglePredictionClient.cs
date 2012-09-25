using System.Net;
using System.Web;
using GooglePredictionDotNet.Constants;
using GooglePredictionDotNet.Helpers;
using GooglePredictionDotNet.Models;
using GooglePredictionDotNet.Models.Serialization;

namespace GooglePredictionDotNet.Services
{
    public class GooglePredictionClient : IGooglePredictionClient
    {
        private readonly string _accessToken;

        /// <summary>
        /// Path to the model data (bucket/data.csv)
        /// </summary>
        public string ModelPath { get; set; }

        public GooglePredictionClient(string accessToken, string modelPath)
        {
            _accessToken = accessToken;
            ModelPath = modelPath;
        }

        /// <summary>
        /// Train the prediction API
        /// </summary>
        /// <returns>True if the data was successfully trained</returns>
        public bool Train()
        {
            try
            {
                var url = string.Format(Urls.Training, _accessToken);

                IWebService webService = new WebService(url);

                var data = new TrainRequest {Id = ModelPath};

                TrainResponse response = webService.Post<TrainRequest, TrainResponse>(data);

                return response.Kind == "prediction#training" && response.Id == data.Id;
            }

            catch (WebException ex)
            {
                ex.CheckAndThrowAuthenticationException();

                throw;
            }
        }

        /// <summary>
        /// Get the current status of training
        /// </summary>
        /// <returns>Prediction API can return Done, Running, or Error </returns>
        public TrainingStatusResponse GetTrainingStatus()
        {
            try
            {
                var encodedModelPath = HttpUtility.UrlEncode(ModelPath);

                var url = string.Format(Urls.TrainingStatus, encodedModelPath, _accessToken);

                IWebService webService = new WebService(url);

                var response = webService.Get<TrainingStatusResponse>();

                return response;
            }
            catch (WebException ex)
            {
                ex.CheckAndThrowAuthenticationException();

                throw;
            }
        }

        /// <summary>
        /// Make a prediction
        /// </summary>
        /// <param name="features">The features for this prediction</param>
        /// <returns>The prediction result</returns>
        public PredictionResponse Predict(params object [] features)
        {
            try
            {
                var encodedModelPath = HttpUtility.UrlEncode(ModelPath);

                var url = string.Format(Urls.Prediction, encodedModelPath, _accessToken);

                IWebService webService = new WebService(url);

                var data = new PredictionRequest() {Input = new PredictionInput() {Features = features}};

                var response = webService.Post<PredictionRequest, PredictionResponse>(data);

                return response;
            }
            catch (WebException ex)
            {
                ex.CheckAndThrowAuthenticationException();

                throw;
            }
        }
    }
}
