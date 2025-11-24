# Example GraphQL Queries for PokemonGraphQL API

# Connect to: http://localhost:5000/graphql

## Query 1: Get a single Pokémon with all details
query GetPikachu {
  pokemon(nameOrId: "pikachu") {
    id
    name
    height
    weight
    baseExperience
    types {
      slot
      type {
        name
        url
      }
    }
    abilities {
      isHidden
      slot
      ability {
        name
        url
      }
    }
    stats {
      baseStat
      effort
      stat {
        name
        url
      }
    }
    sprites {
      frontDefault
      frontShiny
      backDefault
      other {
        officialArtwork {
          frontDefault
          frontShiny
        }
        dreamWorld {
          frontDefault
        }
      }
    }
  }
}

## Query 2: Get a list of Pokémon (paginated)
query GetPokemonList {
  pokemons(first: 10, offset: 0) {
    totalCount
    pageInfo {
      hasNextPage
      hasPreviousPage
    }
    edges {
      node {
        name
        url
      }
    }
  }
}

## Query 3: Get Pokémon by ID
query GetBulbasaur {
  pokemon(nameOrId: "1") {
    id
    name
    types {
      type {
        name
      }
    }
  }
}

## Query 4: Get an Ability
query GetOvergrowAbility {
  ability(nameOrId: "overgrow") {
    id
    name
    isMainSeries
    generation {
      name
      url
    }
    names {
      name
      language {
        name
      }
    }
    effectEntries {
      effect
      shortEffect
      language {
        name
      }
    }
    pokemon {
      isHidden
      slot
      pokemon {
        name
        url
      }
    }
  }
}

## Query 5: Get a list of Abilities
query GetAbilities {
  abilities(first: 20, offset: 0) {
    totalCount
    pageInfo {
      hasNextPage
    }
    edges {
      node {
        name
        url
      }
    }
  }
}

## Query 6: Get a Move
query GetThunderbolt {
  move(nameOrId: "thunderbolt") {
    id
    name
    accuracy
    power
    pp
    priority
    type {
      name
      url
    }
    damageClass {
      name
      url
    }
    generation {
      name
    }
    effectEntries {
      effect
      shortEffect
      language {
        name
      }
    }
    flavorTextEntries {
      flavorText
      language {
        name
      }
      versionGroup {
        name
      }
    }
  }
}

## Query 7: Get a list of Moves
query GetMoves {
  moves(first: 15, offset: 100) {
    totalCount
    pageInfo {
      hasNextPage
      hasPreviousPage
    }
    edges {
      node {
        name
        url
      }
    }
  }
}

## Query 8: Get a Type with damage relations
query GetElectricType {
  type(nameOrId: "electric") {
    id
    name
    generation {
      name
    }
    damageRelations {
      doubleDamageTo {
        name
        url
      }
      halfDamageTo {
        name
        url
      }
      noDamageTo {
        name
        url
      }
      doubleDamageFrom {
        name
        url
      }
      halfDamageFrom {
        name
        url
      }
      noDamageFrom {
        name
        url
      }
    }
    pokemon {
      slot
      pokemon {
        name
        url
      }
    }
  }
}

## Query 9: Get a list of Types
query GetTypes {
  types(first: 20, offset: 0) {
    totalCount
    edges {
      node {
        name
        url
      }
    }
  }
}

## Query 10: Multiple queries in one request
query MultipleQueries {
  pikachu: pokemon(nameOrId: "pikachu") {
    name
    types {
      type {
        name
      }
    }
  }
  
  charizard: pokemon(nameOrId: "charizard") {
    name
    types {
      type {
        name
      }
    }
  }
  
  electricType: type(nameOrId: "electric") {
    name
    pokemon {
      pokemon {
        name
      }
    }
  }
}

## Query 11: Paginated results with more Pokémon
query GetMorePokemon {
  pokemons(first: 50, offset: 50) {
    totalCount
    pageInfo {
      hasNextPage
      hasPreviousPage
    }
    edges {
      node {
        name
      }
    }
  }
}

## Query 12: Complex nested query
query ComplexQuery {
  pokemon(nameOrId: "mewtwo") {
    id
    name
    height
    weight
    abilities {
      ability {
        name
      }
      isHidden
    }
    types {
      type {
        name
      }
    }
    stats {
      baseStat
      stat {
        name
      }
    }
    moves {
      move {
        name
      }
      versionGroupDetails {
        levelLearnedAt
        moveLearnMethod {
          name
        }
      }
    }
  }
}
