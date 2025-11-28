# PokemonApp

A GraphQL API for querying Pokémon data powered by [PokeAPI](https://pokeapi.co/).


## Getting Started (Backend)

A .NET 10 Backend using Hot Chocolate GraphQL server.

Use your IDE of choice or this command to run the server:
```bash
cd src/Host
dotnet run
```


## Getting Started (Frontend)

A Next.js frontend using Relay for GraphQL queries.

1. Make sure the GraphQL server is running on port 5000 (otherwise adjust configurations manually).
2. Install dependencies and start the dev server:
    ```bash
    cd ui
    yarn
    yarn dev
    ```

The UI will be available at `http://localhost:3000`.


## GraphQL Playground

Open your browser and navigate to [Nitro GraphQL IDE](https://chillicream.com/products/nitro/):

```
http://localhost:5000/graphql
```


## Example Queries

See [http/queries.http](http/queries.http) for executable examples.

### List Pokémon

```graphql
query {
  pokemons(skip: 0, take: 5) {
    items {
      id
      name
      detail {
        baseExperience
        height
        weight
        spriteUrl
        abilities { name shortEffect }
      }
    }
  }
}
```

### Get Pokémon by ID

```graphql
query {
  pokemon(input: { id: 25 }) {
    id
    name
    baseExperience
    height
    weight
    abilities { name shortEffect }
    moves { name power accuracy typeName }
  }
}
```

