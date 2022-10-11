namespace TriageConfigurationWeb
{
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public enum OutputTypeEnum
    {
        HtmlImage = 0,
        HtmlText = 1,
        Text = 2
    }
}
