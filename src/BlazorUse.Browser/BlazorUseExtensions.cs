using BlazorUse.Browser;

namespace BlazorUse;

public static class BlazorUseExtensions
{
    public static ValueTask<UseResult> UseEventListenerAsync(this BlazorUse blazorUse, string eventName,
        Func<Task> callback)
    {
        var useEventListener = blazorUse.GetUseEventListener();
        return useEventListener.CreateAsync(eventName, callback);
    }

    public static ValueTask<UseResult> UseEventListenerAsync(this BlazorUse blazorUse, string eventName,
        Action callback)
    {
        return blazorUse.UseEventListenerAsync(eventName, () =>
        {
            callback();
            return Task.CompletedTask;
        });
    }

    public static ValueTask<UseResult> UseResizeObserverAsync(this BlazorUse blazorUse, string selector,
        Func<Task> callback)
    {
        var useResizeObserver = blazorUse.GetUseResizeObserver();
        return useResizeObserver.CreateAsync(selector, callback);
    }

    private static UseEventListener GetUseEventListener(this BlazorUse blazorUse)
    {
        return blazorUse.Create<UseEventListener>(nameof(UseEventListener));
    }

    private static UseResizeObserver GetUseResizeObserver(this BlazorUse blazorUse)
    {
        return blazorUse.Create<UseResizeObserver>(nameof(UseResizeObserver));
    }
}