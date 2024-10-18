function getElement(elOrString) {
  if (elOrString === "window") {
    return window;
  }

  if (typeof elOrString === 'string') {
    return document.querySelector(elOrString);
  }

  return elOrString;
}

export function useProp(elOrString, name) {
  const el = getElement(elOrString);
  return el ? el[name] : null;
}

export function useSelect(elOrString) {
  const el = getElement(elOrString);
  if (el instanceof HTMLInputElement || el instanceof HTMLTextAreaElement) {
    el.select();
    return;
  }

  throw new Error("Unable to select an invalid element")
}

export function useBlur(elOrString) {
  const el = getElement(elOrString);
  el && el.blur();
}

export function useFocus(elOrString) {
  const el = getElement(elOrString);
  el && el.focus();
}

export function useLog(message, level) {
  const fn = console[level];
  fn && fn(message);
}
