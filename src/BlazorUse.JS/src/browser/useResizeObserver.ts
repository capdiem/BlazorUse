import { DotNet } from "@microsoft/dotnet-js-interop";

import { getElement } from "../utils";

export function useResizeObserver(
  elOrString: elOrString,
  invoker: DotNet.DotNetObject
) {
  const observer = new ResizeObserver(async (entries) => {
    if (!entries || entries.length === 0) return;

    await invoker.invokeMethodAsync("Invoke");
  });

  const element = getElement(elOrString);
  if (element instanceof Window) {
    console.error("useResizeObserver does not support window");
    return;
  }

  observer.observe(element);

  return {
    un: () => {
      invoker.dispose();
      observer.unobserve(element);
      observer.disconnect();
    },
  };
}
