export function useElementBounding(selector, invoker) {
  const observer = new ResizeObserver(async entries => {
    if (!entries || entries.length === 0) return;
    const entry = entries[0];
    await invoker.invokeMethodAsync('Invoke', entry.target.getBoundingClientRect());
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
