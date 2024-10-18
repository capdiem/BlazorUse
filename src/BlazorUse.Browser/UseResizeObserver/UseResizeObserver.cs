namespace BlazorUse.Browser;

public class UseResizeObserver : UseBase
{
    public UseResizeObserver(IJSRuntime jsRuntime) : base(jsRuntime,
        "./_content/BlazorUse.Browser/UseResizeObserver.js")
    {
    }

    public async ValueTask<Registration> CreateAsync(string eventName, Func<Task> callback)
    {
        var module = await GetModuleAsync();
        var registration = await module.InvokeAsync<IJSObjectReference>("useResizeObserver", eventName,
            DotNetObjectReference.Create(new Invoker(callback)));

        return new Registration()
        {
            Un = () => _ = registration.InvokeVoidAsync("un")
        };
    }
}