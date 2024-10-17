export function useEventListener(eventName, invoker) {
  const listener = async e => {
    await invoker.invokeMethodAsync('Invoke');
  };

  const register = {
    fn: listener,
    un: () => {
      invoker.dispose();
      window.removeEventListener(eventName, listener)
    }
  }

  window.addEventListener(eventName, register.fn);

  return register;
}