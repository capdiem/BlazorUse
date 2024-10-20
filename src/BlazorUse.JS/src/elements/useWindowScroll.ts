import { DotNet } from "@microsoft/dotnet-js-interop";

export function useWindowScroll(invoker: DotNet.DotNetObject) {
  const listener = async () => {
    await invoker.invokeMethodAsync("Invoke", {
      x: window.scrollX,
      y: window.scrollY,
    });
  };

  const register = {
    scrollTo: (options: ScrollToOptions) => {
      window.scrollTo(options);
    },
    un: () => {
      invoker.dispose();
      window.removeEventListener("scroll", listener);
    },
  };

  window.addEventListener("scroll", listener, {
    capture: false,
    passive: true,
  });

  return register;
}
