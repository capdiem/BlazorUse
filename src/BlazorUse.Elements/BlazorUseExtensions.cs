namespace BlazorUse.Elements;

public static class BlazorUseExtensions
{
    public static async ValueTask<Registration> UseElementSizeAsync(this BlazorUse blazorUse, string selector,
        Func<Size, Task> callback)
    {
        var useElementSize = blazorUse.GetUseElementSize();
        return await useElementSize.CreateAsync(selector, callback);
    }

    public static async ValueTask<Registration> UseWindowScrollAsync(this BlazorUse blazorUse,
        Func<ScrollPosition, Task> callback)
    {
        var useWindowScroll = blazorUse.GetWindowScroll();
        return await useWindowScroll.CreateAsync(callback);
    }

    private static UseElementSize GetUseElementSize(this BlazorUse blazorUse)
    {
        return blazorUse.Create<UseElementSize>(nameof(UseElementSize));
    }

    private static UseWindowScroll GetWindowScroll(this BlazorUse blazorUse)
    {
        return blazorUse.Create<UseWindowScroll>(nameof(UseWindowScroll));
    }
}