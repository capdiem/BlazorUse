function getElement(elOrString) {
  if (elOrString === "window") {
    return window;
  }

  if (typeof elOrString === 'string') {
    return document.querySelector(elOrString);
  }

  return elOrString;
}


export function useLog(message, level) {
  const fn = console[level];
  fn && fn(message);
}
