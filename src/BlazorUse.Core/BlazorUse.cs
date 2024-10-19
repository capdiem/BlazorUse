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


    public async Task UseLogAsync(string message, string level = "log")
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("useLog", message, level);
    }

    public void UseLog(string message, string level = "log") => _ = UseLogAsync(message, level);
}