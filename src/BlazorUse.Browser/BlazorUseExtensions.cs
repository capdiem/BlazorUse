using BlazorUse.Browser;

namespace BlazorUse;

public static class BlazorUseExtensions
{
    public static ValueTask<UseResult> UseEventListenerAsync(this IBlazorUse blazorUse, string eventName,
        Func<Task> callback)
    {
        var useEventListener = blazorUse.GetUseEventListener();
        return useEventListener.CreateAsync(eventName, callback);
    }

    public static ValueTask<UseResult> UseEventListenerAsync(this IBlazorUse blazorUse, string eventName,
        Action callback)
    {
        return blazorUse.UseEventListenerAsync(eventName, () =>
        {
            callback();
            return Task.CompletedTask;
        });
    }

    public static ValueTask<UseResult> UseResizeObserverAsync(this IBlazorUse blazorUse, string selector,
        Func<Task> callback)
    {
        var useResizeObserver = blazorUse.GetUseResizeObserver();
        return useResizeObserver.CreateAsync(selector, callback);
    }
    
    public static async ValueTask UseLogAsync(this IBlazorUse blazorUse, string message, string level = "log")
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useLog", message, level);
    }

    private static UseEventListener GetUseEventListener(this IBlazorUse blazorUse)
    {
        return (blazorUse as BlazorUse)!.Create<UseEventListener>(nameof(UseEventListener));
    }

    private static UseResizeObserver GetUseResizeObserver(this IBlazorUse blazorUse)
    {
        return (blazorUse as BlazorUse)!.Create<UseResizeObserver>(nameof(UseResizeObserver));
    }

    private static Task<IJSObjectReference> GetUseAtomicJSModuleAsync(this IBlazorUse blazorUse)
    {
        var useAtomic = (blazorUse as BlazorUse)!.Create<UseAtomic>(nameof(UseAtomic));
        return useAtomic.GetModuleAsync();
    }
}