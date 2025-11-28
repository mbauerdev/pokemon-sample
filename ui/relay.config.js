module.exports = {
  src: "./src",
  language: "typescript",
  schema: "./src/schema/server.graphql",
  artifactDirectory: "./src/__generated__",
  exclude: ["**/node_modules/**", "**/__mocks__/**", "**/__generated__/**"],
};
