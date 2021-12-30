using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.ML;
using Microsoft.ML.Transforms.Image;

namespace AlexNet
{
    internal class Alexnet
    {
        PredictionEngine<imageInput, Prediction> predictionEngine;


        public Alexnet()
        {
            //get the full path of the onnx-model (alexnet)
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"model\alexnet1.onnx");
            

            var context = new MLContext();

            var emptyData = new List<imageInput>();

            var data = context.Data.LoadFromEnumerable(emptyData);

           
            // create the data-pipeline which transforms an image into a valid input for alexnet (resize to 224x224 and scale according to alexnet's requirements [see README])
            var pipeline = context.Transforms.ResizeImages(resizing: Microsoft.ML.Transforms.Image.ImageResizingEstimator.ResizingKind.IsoCrop,
                outputColumnName: "data", imageWidth: ImageSettings.imageWidth, imageHeight: ImageSettings.imageHeight, inputColumnName: nameof(imageInput.Image))
                .Append(context.Transforms.ExtractPixels(outputColumnName: "data", scaleImage: 0.226f, offsetImage: 0.449f, outputAsFloatArray : true))
                .Append(context.Transforms.ApplyOnnxModel(modelFile: path, outputColumnName: "output1", inputColumnName: "data"));

            
            // apply the model to alexnet (the model)
            var model = pipeline.Fit(data);
            
            predictionEngine = context.Model.CreatePredictionEngine<imageInput, Prediction>(model);
        }


        /// <summary>
        /// Takes an image and passes it to the model
        /// </summary>
        /// <param name="img">
        /// The image to be classified
        /// </param>
        /// <returns>
        /// Predictions of the content of the image based on the 1000 classes alexnet can predict
        /// </returns>
        public Dictionary<String, float> predict(Image img)
        {
            // pass an image to the predictionengine/alexnet
            var output = predictionEngine.Predict(new imageInput { Image = (Bitmap)img });
            return  ParseOutputs(output.PredictedLabels);
        }

        /// <summary>
        /// Helper function for Alexnet.predict() that transforms the raw output of the model into a neat dictionary.
        /// </summary>
        /// <param name="predictions">
        /// The raw output of the model/predictionengine
        /// </param>
        /// <returns>
        /// A dictionary with 1000 key-value-pairs. The keys are the classes alexnet can predict, and values are the predicted "probability" of the class
        /// </returns>
        private Dictionary<String, float> ParseOutputs(float[] predictions)
        {
            // find and read the file containing the labels/classes that alexnet predict
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"model\labels.txt");
            string[] labels = File.ReadAllLines(path);

            //Applying the softmax-function to the output of the network
            float sum = predictions.Sum(x => (float)Math.Exp(x));
            for (var i = 1; i < predictions.Length; i++)
            {
                predictions[i] = (float)Math.Exp(predictions[i]) / sum;
            }

            // make the predictions of alexnet into a dictionay (i.e. class : predictionvalue) and sort by predictionvalue
            var matches = labels.Zip(predictions, (s, i) => new { s, i }).ToDictionary(item => item.s, item => item.i);
            var sortedMatches = from entry in matches orderby entry.Value descending select entry;

            return sortedMatches.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }

    #region Helper Classes
    /// <summary>
    /// Specify how the output of the model will look like (for the ML.net framework)
    /// </summary>
    class Prediction
    {
        [Microsoft.ML.Data.ColumnName("output1")]
        public float[] PredictedLabels { get; set; }
    }
    /// <summary>
    /// Specify how the input to the model will look like (for the ML.net framework)
    /// </summary>
    internal class imageInput
    {
        
        [ImageType(ImageSettings.imageHeight, ImageSettings.imageWidth)]
        public Bitmap Image { get; set; }


    }



    public struct ImageSettings
    {
        public const int imageHeight = 224;
        public const int imageWidth = 224;
    }
    #endregion
}
