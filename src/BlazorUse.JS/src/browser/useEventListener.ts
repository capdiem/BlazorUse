import { DotNet } from "@microsoft/dotnet-js-interop";

export function useEventListener(
  eventName: string,
  invoker: DotNet.DotNetObject
) {
  const listener = async (e) => {
    await invoker.invokeMethodAsync("Invoke");
  };

  const register = {
    un: () => {
      invoker.dispose();
      window.removeEventListener(eventName, listener);
    },
  };

  window.addEventListener(eventName, listener);

  return register;
}
