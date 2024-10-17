export function useWindowScroll(invoker) {
  const listener = async e => {
    await invoker.invokeMethodAsync('Invoke', {
      x: window.scrollX,
      y: window.scrollY
    });
  };

  const register = {
    un: () => {
      invoker.dispose();
      window.removeEventListener('scroll', listener)
    }
  }

  window.addEventListener('scroll', listener, {
    capture: false,
    passive: true
  });

  return register;
}