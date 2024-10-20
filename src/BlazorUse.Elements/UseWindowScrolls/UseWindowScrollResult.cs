namespace BlazorUse.Elements;

public class UseWindowScrollResult : UseResult
{
    private double _x;
    private double _y;

    public double X
    {
        get => _x;
        set
        {
            _x = value;
            ScrollTo(new ScrollToOptions(_x, Y, ScrollBehavior.smooth));
        }
    }

    public double Y
    {
        get => _y;
        set
        {
            _y = value;
            ScrollTo(new ScrollToOptions(X, _y, ScrollBehavior.smooth));
        }
    }

    internal void UpdatePositionNoEffect(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public Action<ScrollToOptions> ScrollTo { get; internal set; }
}