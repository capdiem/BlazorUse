namespace BlazorUse.Browser;

public class UseEventListener : UseBase
{
    public UseEventListener(IJSRuntime jsRuntime) : base(jsRuntime, "./_content/BlazorUse.Browser/UseEventListener.js")
    {
    }

    public async ValueTask<Registration> CreateAsync(string eventName, Func<Task> callback)
    {
        var module = await GetModuleAsync();
        var registration = await module.InvokeAsync<IJSObjectReference>("useEventListener", eventName,
            DotNetObjectReference.Create(new Invoker(callback)));

        return new Registration()
        {
            Un = () => _ = registration.InvokeVoidAsync("un")
        };
    }
}