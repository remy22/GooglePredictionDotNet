
using System;

namespace GooglePredictionDotNet.Models
{
    public enum TrainingStatus
    {
        Running,
        Done,
        Error,
        NotFound    
    }

    public static class TrainingStatusHelpers
    {
        public static TrainingStatus GetStatus(this string message)
        {
            switch(message)
            {
                case "RUNNING":
                    return TrainingStatus.Running;
                case "DONE":
                    return TrainingStatus.Done;
                case "ERROR":
                    return TrainingStatus.Error;
                case "ERROR: TRAINING JOB NOT FOUND":
                    return TrainingStatus.NotFound;
                default:
                    throw new ArgumentException("Invalid training status sent from Google");
            }
        }
    }
}
