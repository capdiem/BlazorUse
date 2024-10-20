namespace BlazorUse.Elements;

public class UseWindowScroll : UseBase
{
    public UseWindowScroll(IJSRuntime jsRuntime) : base(jsRuntime,
        "./_content/BlazorUse.Elements/useWindowScroll.js")
    {
    }

    public async ValueTask<UseWindowScrollResult> CreateAsync(Func<ScrollPosition, Task>? callback)
    {
        var module = await GetModuleAsync();

        UseWindowScrollResult result = new();

        var jsObjRef = await module.InvokeAsync<IJSObjectReference>("useWindowScroll",
            DotNetObjectReference.Create(new Invoker<ScrollPosition>(async position =>
            {
                result.UpdatePositionNoEffect(position.X, position.Y);

                if (callback != null)
                {
                    await callback(position);
                }
            })));

        result.ScrollTo = (options) => _ = jsObjRef.InvokeVoidAsync("scrollTo", options);
        result.Un = () => _ = jsObjRef.InvokeVoidAsync("un");

        return result;
    }
}