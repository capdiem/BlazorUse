using Microsoft.AspNetCore.Components;

namespace BlazorUse.Elements;

public static class BlazorUseExtensions
{
    public static async ValueTask<UseResult> UseElementSizeAsync(this BlazorUse blazorUse,
        string selector,
        Func<BoundingRect, Task> callback)
    {
        var useElementSize = blazorUse.GetUseElementSize();
        return await useElementSize.CreateAsync(selector, callback);
    }

    public static async ValueTask<UseWindowScrollResult> UseWindowScrollAsync(this BlazorUse blazorUse,
        Func<ScrollPosition, Task>? callback = null)
    {
        var useWindowScroll = blazorUse.GetUseWindowScroll();
        return await useWindowScroll.CreateAsync(callback);
    }

    public static async ValueTask<T> UsePropAsync<T>(this BlazorUse blazorUse, string selector, string prop)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        return await useAtomicJsModule.InvokeAsync<T>("useProp", selector, prop);
    }

    public static async ValueTask UseFocusAsync(this BlazorUse blazorUse, string selector)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useFocus", selector);
    }

    public static async ValueTask UseFocusAsync(this BlazorUse blazorUse, ElementReference elementReference)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useFocus", elementReference);
    }

    public static async ValueTask UseBlurAsync(this BlazorUse blazorUse, string selector)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useBlur", selector);
    }

    public static async ValueTask UseBlurAsync(this BlazorUse blazorUse, ElementReference elementReference)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useBlur", elementReference);
    }

    public static async ValueTask UseSelectAsync(this BlazorUse blazorUse, string selector)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useSelect", selector);
    }

    public static async ValueTask UseSelectAsync(this BlazorUse blazorUse, ElementReference elementReference)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        await useAtomicJsModule.InvokeVoidAsync("useSelect", elementReference);
    }

    public static async ValueTask<BoundingRect> UseBoundingRectAsync(this BlazorUse blazorUse, string selector)
    {
        var useAtomicJsModule = await blazorUse.GetUseAtomicJSModuleAsync();
        return await useAtomicJsModule.InvokeAsync<BoundingRect>("useBoundingRect", selector);
    }

    private static UseElementBounding GetUseElementSize(this BlazorUse blazorUse)
    {
        return blazorUse.Create<UseElementBounding>(nameof(UseElementBounding));
    }

    private static UseWindowScroll GetUseWindowScroll(this BlazorUse blazorUse)
    {
        return blazorUse.Create<UseWindowScroll>(nameof(UseWindowScroll));
    }

    private static Task<IJSObjectReference> GetUseAtomicJSModuleAsync(this BlazorUse blazorUse)
    {
        var useAtomic = blazorUse.Create<UseAtomic>(nameof(UseAtomic));
        return useAtomic.GetModuleAsync();
    }
}