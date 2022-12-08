using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;

internal class Program
{
    private static void Main(string[] args)
    {
        // Gate to prevent the program from running if no arguments are passed in
        if (args.Length == 0)
        {
            Console.WriteLine("Please pass in the path to the data file as an argument");
            return;
        }

        // Reading Data from Text file 
        var fileName = args[0];

        var data = ReadAndPreprocessTextData(args[0]);

        // Create a new MLContext
        var mlContext = new MLContext();

        // Convert data to IDataView
        var dataView = mlContext.Data.LoadFromEnumerable(data);

        // Create a pipeline to preprocess the data
        var textPipeline = mlContext.Transforms.Text.FeaturizeText("Features", "Text");

        // Fit the pipeline to the data
        var textTransformer = textPipeline.Fit(dataView);

        // text transformer now has a sparse vector of 3138 Singles 
    }

    private static IEnumerable<TextData> ReadAndPreprocessTextData(string filename)
    {
        // Read the text data 
        var lines = File.ReadAllLines(filename);

        // Tokenize the text data
        var tokens = lines.SelectMany(line => line.Split(' '));

        // clean tokens from empty strings and spaces 
        tokens = tokens.Where(token => !string.IsNullOrWhiteSpace(token));

        // Return the data as a sequence of TextData objects
        return tokens.Select(token => new TextData { Text = token });
    }
}