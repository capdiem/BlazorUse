export function useElementSize(selector, invoker) {
  const observer = new ResizeObserver(async entries => {
    if (!entries || entries.length === 0) return;
    const entry = entries[0];
    await invoker.invokeMethodAsync('Invoke', {
      width: entry.contentRect.width,
      height: entry.contentRect.height
    });
  });

  const element = document.querySelector(selector);
  observer.observe(element);

  return {
    un: () => {
      invoker.dispose();
      observer.unobserve(element)
      observer.disconnect();
    }
  }
}
