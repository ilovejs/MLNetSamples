using System;
using SampleBinaryClassification.Model.DataModels;
using Microsoft.ML;

namespace consumeModelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeModel();
        }
        private const string MODEL_FILEPATH = @"/Users/mike/Code/AI/MLNET/myMLApp/SampleBinaryClassification/SampleBinaryClassification.Model/MLModel.zip";
        public static void ConsumeModel()
        {
            // Load the model
            MLContext mlContext = new MLContext();

            ITransformer mlModel = mlContext.Model.Load(MODEL_FILEPATH, out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // Use the code below to add input data
            var input = new ModelInput();
            // DATA: inference
            input.SentimentText = "That is rude";

            // Try model on sample data
            // True is toxic, false is non-toxic
            ModelOutput result = predEngine.Predict(input);

            Console.WriteLine($"Text: {input.SentimentText} | Prediction: {(Convert.ToBoolean(result.Prediction) ? "Toxic" : "Non-toxic")} sentiment");
        }
    }
}