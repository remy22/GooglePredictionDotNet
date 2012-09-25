using GooglePredictionDotNet.Models;
using GooglePredictionDotNet.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GooglePredictionDotNet.Tests
{
    
    
    /// <summary>
    ///This is a test class for GooglePredictionClientTest and is intended
    ///to contain all GooglePredictionClientTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GooglePredictionClientTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        private const string _accessToken = ""; //TODO: set your OAuth2 access token
        private const string _model = ""; //google storage path to your training data (bucketname/data.csv)

        /// <summary>
        ///A test for Train
        ///</summary>
        [TestMethod()]
        public void TrainData_Success_Test()
        {
            GooglePredictionClient target = new GooglePredictionClient(_accessToken, _model);

            bool actual = target.Train();
        }

        /// <summary>
        ///A test for Train
        ///</summary>
        [TestMethod()]
        public void TrainingStatus_Running_or_Done_Test()
        {
            GooglePredictionClient target = new GooglePredictionClient(_accessToken, _model);

            var actual = target.GetTrainingStatus();

            Assert.IsTrue(actual.TrainingStatus == "RUNNING" || actual.TrainingStatus == "DONE");
        }

        /// <summary>
        ///A test for Train
        ///</summary>
        [TestMethod()]
        public void PredictionTest()
        {
            GooglePredictionClient target = new GooglePredictionClient(_accessToken, _model);

            //TODO: Set the phrase and resulting category
            var actual = target.Predict("phrase to predict");

            Assert.AreEqual("Category", actual.OutputLabel);
        }
    }
}
