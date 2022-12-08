

using TensorExperiment.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        // TODO: introduce DI container
        // TODO: introduce logging

        // Gate to prevent the program from running if no arguments are passed in
        if (args.Length == 0)
        {
            Console.WriteLine("Please pass in the path to the data file as an argument");
            return;
        }

        // Reading Data from Text file 
        var fileName = args[0];

        // Create a new Vocabulary
        var vocabulary = new Vocabulary(fileName);
        
        // // Create a new MLContext
        // var mlContext = new MLContext();

        // // Convert data to IDataView
        // var dataView = mlContext.Data.LoadFromEnumerable(data);

        // // Create a pipeline to preprocess the data
        // var textPipeline = mlContext.Transforms.Text.FeaturizeText("Features", "Text");

        // // Fit the pipeline to the data
        // var textTransformer = textPipeline.Fit(dataView);

        // // text transformer now has a sparse vector of 3138 Singles 

    }


}