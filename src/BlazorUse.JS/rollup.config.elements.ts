import { globSync } from "glob";
import { defineConfig } from "rollup";

import nodeResolve from "@rollup/plugin-node-resolve";
import terser from "@rollup/plugin-terser";
import typescript from "@rollup/plugin-typescript";

export default defineConfig({
  input: globSync("src/elements/*.ts"),
  output: {
    dir: "../BlazorUse.Elements/wwwroot",
    format: "es",
    chunkFileNames: "[name].js",
    // sourcemap: true,
  },
  plugins: [
    typescript(),
    // nodeResolve(),
    terser(),
  ],
});
