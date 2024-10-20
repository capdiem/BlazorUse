export function useLog(message, level) {
  const fn = console[level];
  fn && fn(message);
}
