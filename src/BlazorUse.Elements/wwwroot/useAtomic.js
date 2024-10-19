import {getElement} from "/_content/BlazorUse.Elements/utils.js";

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

export function useBoundingRect(elOrString) {
  const el = getElement(elOrString);
  return el ? el.getBoundingClientRect() : null;
}
