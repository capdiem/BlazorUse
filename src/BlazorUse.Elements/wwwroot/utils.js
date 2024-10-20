export function getElement(elOrString) {
  if (elOrString === "window") {
    return window;
  }

  if (typeof elOrString === 'string') {
    return document.querySelector(elOrString);
  }

  return elOrString;
}