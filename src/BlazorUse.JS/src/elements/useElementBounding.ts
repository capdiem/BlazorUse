import { DotNet } from "@microsoft/dotnet-js-interop";

import { getElement } from "../utils";

export function useElementBounding(
  elOrString: elOrString,
  invoker: DotNet.DotNetObject
) {
  const observer = new ResizeObserver(async (entries) => {
    if (!entries || entries.length === 0) return;
    const entry = entries[0];
    await invoker.invokeMethodAsync(
      "Invoke",
      entry.target.getBoundingClientRect()
    );
  });

  const element = getElement(elOrString);
  if (element instanceof Window) {
    console.error("useElementBounding does not support window");
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
