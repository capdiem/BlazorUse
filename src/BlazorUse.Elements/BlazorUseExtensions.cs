namespace BlazorUse.Elements;

public static class BlazorUseExtensions
{
    public static async ValueTask<Registration> UseElementSizeAsync(this BlazorUse blazorUse, string selector,
        Func<Size, Task> callback)
    {
        var useElementSize = new UseElementSize(blazorUse.GetJSRuntime());
        return await useElementSize.CreateAsync(selector, callback);
    }

    public static async ValueTask<Registration> UseWindowScrollAsync(this BlazorUse blazorUse,
        Func<ScrollPosition, Task> callback)
    {
        var useWindowScroll = new UseWindowScroll(blazorUse.GetJSRuntime());
        return await useWindowScroll.CreateAsync(callback);
    }
}