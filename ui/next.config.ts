import type { NextConfig } from "next";
const relay = require("./relay.config");

const nextConfig: NextConfig = {
  /* config options here */
  reactCompiler: true,
  compiler: {
    relay,
  },
};

export default nextConfig;
