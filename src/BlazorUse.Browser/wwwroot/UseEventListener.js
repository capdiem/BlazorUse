export function useEventListener(eventName, invoker) {
  const listener = async e => {
    await invoker.invokeMethodAsync('Invoke');
  };

  const register = {
    un: () => {
      invoker.dispose();
      window.removeEventListener(eventName, listener)
    }
  }

  window.addEventListener(eventName, listener);

  return register;
}