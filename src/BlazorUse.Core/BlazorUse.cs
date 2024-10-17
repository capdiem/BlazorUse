namespace BlazorUse;

public class BlazorUse
{
    private readonly IJSRuntime _jsRuntime;

    public BlazorUse(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public IJSRuntime GetJSRuntime() => _jsRuntime;
}