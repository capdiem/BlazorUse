export function getElement(
  elOrString: HTMLElement | string
): Window | HTMLElement | null {
  if (elOrString === "window") {
    return window;
  }

  if (typeof elOrString === "string") {
    return document.querySelector(elOrString) as HTMLElement | null;
  }

  return elOrString;
}
