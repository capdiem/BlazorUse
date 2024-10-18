using System.Collections.Concurrent;

namespace BlazorUse;

public class BlazorUse : UseBase
{
    private readonly ConcurrentDictionary<string, object> _useDic = new();
    private readonly IJSRuntime _jsRuntime;

    public BlazorUse(IJSRuntime jsRuntime) : base(jsRuntime, "./_content/BlazorUse.Core/blazor-use.js")
    {
        _jsRuntime = jsRuntime;
    }

    public T Create<T>(string identifier) where T : UseBase
    {
        if (_useDic.TryGetValue(identifier, out var use))
        {
            return (T)use;
        }

        var instance = (T)Activator.CreateInstance(typeof(T), _jsRuntime)!;
        _useDic.TryAdd(identifier, instance);
        return instance;
    }

    public async ValueTask<T> UsePropAsync<T>(string selector, string prop)
    {
        var module = await GetModuleAsync();
        return await module.InvokeAsync<T>("useProp", selector, prop);
    }

    public async ValueTask<T> UsePropAsync<T>(ElementReference element, string prop)
    {
        var module = await GetModuleAsync();
        return await module.InvokeAsync<T>("useProp", element, prop);
    }

    public async Task UseSelectAsync(string selector)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("useSelect", selector);
    }

    public async Task UseSelectAsync(ElementReference element)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("useSelect", element);
    }

    public void UseSelect(string selector) => _ = UseSelectAsync(selector);

    public void UseSelect(ElementReference element) => _ = UseSelectAsync(element);

    public async Task UseBlurAsync(string selector)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("useBlur", selector);
    }

    public async Task UseBlurAsync(ElementReference element)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("useBlur", element);
    }

    public void UseBlur(string selector) => _ = UseBlurAsync(selector);

    public void UseBlur(ElementReference element) => _ = UseBlurAsync(element);

    public async Task UseFocusAsync(string selector)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("useFocus", selector);
    }

    public async Task UseFocusAsync(ElementReference element)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("useFocus", element);
    }

    public void UseFocus(string selector) => _ = UseFocusAsync(selector);

    public void UseFocus(ElementReference element) => _ = UseFocusAsync(element);

    public async Task UseLogAsync(string message, string level = "log")
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("useLog", message, level);
    }

    public void UseLog(string message, string level = "log") => _ = UseLogAsync(message, level);
}