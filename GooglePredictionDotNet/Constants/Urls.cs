
namespace GooglePredictionDotNet.Constants
{
    public static class Urls
    {
        public const string Training = "https://www.googleapis.com/prediction/v1.2/training?oauth_token={0}";
        public const string TrainingStatus = "https://www.googleapis.com/prediction/v1.2/training/{0}?oauth_token={1}";
        public const string Prediction = "https://www.googleapis.com/prediction/v1.2/training/{0}/predict?oauth_token={1}";
    }
}
