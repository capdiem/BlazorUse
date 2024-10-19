namespace BlazorUse.Elements;

public class UseElementBounding : UseBase
{
    public UseElementBounding(IJSRuntime jsRuntime) : base(jsRuntime,
        "./_content/BlazorUse.Elements/useElementBounding.js")
    {
    }

    public async ValueTask<UseResult> CreateAsync(string selector, Func<BoundingRect, Task>? callback = null)
    {
        var module = await GetModuleAsync();

        UseElementBoundingResult result = new();

        var jsObjRef = await module.InvokeAsync<IJSObjectReference>("useElementBounding", selector,
            DotNetObjectReference.Create(new Invoker<BoundingRect>(async size =>
            {
                result.Bottom = size.Bottom;
                result.Height = size.Height;
                result.Left = size.Left;
                result.Right = size.Right;
                result.Top = size.Top;
                result.Width = size.Width;
                result.X = size.X;
                result.Y = size.Y;

                if (callback is not null)
                {
                    await callback.Invoke(size);
                }
            })));

        result.Un = () => _ = jsObjRef.InvokeVoidAsync("un");

        return result;
    }
}