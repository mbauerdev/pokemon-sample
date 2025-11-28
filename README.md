# PokemonApp

A GraphQL API for querying Pokémon data powered by [PokeAPI](https://pokeapi.co/).

## Getting Started

```bash
cd src/Host
dotnet run
```

## GraphQL Playground

Open your browser and navigate to [Nitro GraphQL IDE](https://chillicream.com/products/nitro/):

```
http://localhost:5089/graphql
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
