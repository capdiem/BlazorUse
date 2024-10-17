namespace BlazorUse.Elements;

public abstract class UseBase : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    protected UseBase(IJSRuntime jsRuntime, string modulePath)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() =>
            jsRuntime.InvokeAsync<IJSObjectReference>("import", modulePath).AsTask());
    }

    protected Task<IJSObjectReference> GetModuleAsync() => _moduleTask.Value;

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}