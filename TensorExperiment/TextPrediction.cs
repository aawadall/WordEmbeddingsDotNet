using Microsoft.ML.Data;

internal class TextPrediction
{
    [ColumnName("Prediction")]
    public bool Prediction { get; set; }
}