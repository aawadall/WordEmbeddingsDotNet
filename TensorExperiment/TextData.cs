using Microsoft.ML.Data;

internal class TextData
{
    [ColumnName("Text")]
    public string? Text { get; set; }
}