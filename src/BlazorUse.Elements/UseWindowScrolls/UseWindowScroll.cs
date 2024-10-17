namespace BlazorUse.Elements;

public class UseWindowScroll : UseBase
{
    public UseWindowScroll(IJSRuntime jsRuntime) : base(jsRuntime,
        "./_content/BlazorUse.Elements/UseWindowScroll.js")
    {
    }

    public async ValueTask<Registration> CreateAsync(Func<ScrollPosition, Task> callback)
    {
        var module = await GetModuleAsync();
        var registration = await module.InvokeAsync<IJSObjectReference>("useWindowScroll",
            DotNetObjectReference.Create(new Invoker<ScrollPosition>(callback)));

        return new Registration()
        {
            Un = () => _ = registration.InvokeVoidAsync("un")
        };
    }
}