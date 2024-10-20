using Microsoft.AspNetCore.Components;

namespace BlazorUse.Elements;

public static class BlazorUseExtensions
{
    public static async ValueTask<UseResult> UseElementSizeAsync(this IBlazorUse blazorUse,
        string selector,
        Func<BoundingRect, Task> callback)
    {
        var useElementSize = blazorUse.GetUseElementSize();
        return await useElementSize.CreateAsync(selector, callback);
    }

    public static async ValueTask<UseWindowScrollResult> UseWindowScrollAsync(this IBlazorUse blazorUse,
        Func<ScrollPosition, Task>? callback = null)
    {
        var useWindowScroll = blazorUse.GetUseWindowScroll();
        return await useWindowScroll.CreateAsync(callback);
    }

    public static async ValueTask<T> UsePropAsync<T>(this IBlazorUse blazorUse, string selector, string prop)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        return await useAtomicJsModule.InvokeAsync<T>("useProp", selector, prop);
    }

    public static async ValueTask UseFocusAsync(this IBlazorUse blazorUse, string selector)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useFocus", selector);
    }

    public static async ValueTask UseFocusAsync(this IBlazorUse blazorUse, ElementReference elementReference)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useFocus", elementReference);
    }

    public static async ValueTask UseBlurAsync(this IBlazorUse blazorUse, string selector)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useBlur", selector);
    }

    public static async ValueTask UseBlurAsync(this IBlazorUse blazorUse, ElementReference elementReference)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useBlur", elementReference);
    }

    public static async ValueTask UseSelectAsync(this IBlazorUse blazorUse, string selector)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useSelect", selector);
    }

    public static async ValueTask UseSelectAsync(this IBlazorUse blazorUse, ElementReference elementReference)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useSelect", elementReference);
    }

    public static async ValueTask<BoundingRect> UseBoundingRectAsync(this IBlazorUse blazorUse, string selector)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        return await useAtomicJsModule.InvokeAsync<BoundingRect>("useBoundingRect", selector);
    }

    private static UseElementBounding GetUseElementSize(this IBlazorUse blazorUse)
    {
        return (blazorUse as BlazorUse)!.Create<UseElementBounding>(nameof(UseElementBounding));
    }

    private static UseWindowScroll GetUseWindowScroll(this IBlazorUse blazorUse)
    {
        return (blazorUse as BlazorUse)!.Create<UseWindowScroll>(nameof(UseWindowScroll));
    }

    private static Task<IJSObjectReference> GetUseAtomicJSModuleAsync(this IBlazorUse blazorUse)
    {
        var useAtomic = (blazorUse as BlazorUse)!.Create<UseAtomic>(nameof(UseAtomic));
        return useAtomic.GetModuleAsync();
    }
}