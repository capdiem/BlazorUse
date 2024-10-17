export function useResizeObserver(selector, invoker) {
  const observer = new ResizeObserver(async entries => {
    if (!entries || entries.length === 0) return;

    await invoker.invokeMethodAsync('Invoke');
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
