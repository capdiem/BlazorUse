namespace BlazorUse.Elements;

public class UseElementSize : UseBase
{
    public UseElementSize(IJSRuntime jsRuntime) : base(jsRuntime, "./_content/BlazorUse.Elements/UseElementSize.js")
    {
    }

    public async ValueTask<Registration> CreateAsync(string selector, Func<Size, Task> callback)
    {
        var module = await GetModuleAsync();
        var registration = await module.InvokeAsync<IJSObjectReference>("useElementSize", selector,
            DotNetObjectReference.Create(new Invoker<Size>(callback)));

        return new Registration()
        {
            Un = () => _ = registration.InvokeVoidAsync("un")
        };
    }
}