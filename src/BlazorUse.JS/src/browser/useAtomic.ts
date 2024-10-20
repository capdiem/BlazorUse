export function useLog(message: string, level: string = "log") {
  const fn = console[level];
  fn && fn(message);
}
