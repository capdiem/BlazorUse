import { getElement } from "../utils";

export function useProp(elOrString: elOrString, name: string) {
  const el = getElement(elOrString);
  return el ? el[name] : null;
}

export function useSelect(elOrString: elOrString) {
  const el = getElement(elOrString);
  if (el instanceof HTMLInputElement || el instanceof HTMLTextAreaElement) {
    el.select();
    return;
  }

  throw new Error("Unable to select an invalid element");
}

export function useBlur(elOrString: elOrString) {
  const el = getElement(elOrString);
  el && el.blur();
}

export function useFocus(elOrString: elOrString) {
  const el = getElement(elOrString);
  el && el.focus();
}

export function useBoundingRect(elOrString: elOrString) {
  const el = getElement(elOrString);
  if (el instanceof Window) {
    console.error("useBoundingRect does not support window");
    return;
  }
  return el ? el.getBoundingClientRect() : null;
}
