using System.Text.Json.Serialization;

namespace BlazorUse.Elements;

public class ScrollToOptions
{
    public double? Left { get; set; }

    public double? Top { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ScrollBehavior Behavior { get; set; }

    public ScrollToOptions()
    {
    }

    public ScrollToOptions(double? left, double? top, ScrollBehavior behavior)
    {
        Left = left;
        Top = top;
        Behavior = behavior;
    }
}

public enum ScrollBehavior
{
    auto,
    instant,
    smooth
}