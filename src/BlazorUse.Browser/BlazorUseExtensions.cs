using BlazorUse.Browser;

namespace BlazorUse;

public static class BlazorUseExtensions
{
    public static ValueTask<Registration> UseEventListenerAsync(this BlazorUse blazorUse, string eventName,
        Func<Task> callback)
    {
        var useEventListener = new UseEventListener(blazorUse.GetJSRuntime());
        return useEventListener.CreateAsync(eventName, callback);
    }

    public static ValueTask<Registration> UseEventListenerAsync(this BlazorUse blazorUse, string eventName,
        Action callback)
    {
        return blazorUse.UseEventListenerAsync(eventName, () =>
        {
            callback();
            return Task.CompletedTask;
        });
    }

    public static ValueTask<Registration> UseResizeObserverAsync(this BlazorUse blazorUse, string selector,
        Func<Task> callback)
    {
        var useResizeObserver = new UseResizeObserver(blazorUse.GetJSRuntime());
        return useResizeObserver.CreateAsync(selector, callback);
    }
}