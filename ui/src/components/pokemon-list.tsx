"use client";

import { graphql, useLazyLoadQuery } from "react-relay";
import { pokemonListQuery } from "@/__generated__/pokemonListQuery.graphql";

export function PokemonList() {
  const data = useLazyLoadQuery<pokemonListQuery>(
    graphql`
      query pokemonListQuery {
        pokemons(skip: 0, take: 20) {
          items {
            name
          }
        }
      }
    `,
    {}
  );

  if (!data.pokemons?.items) {
    return null;
  }

  return (
    <ul>
      {data.pokemons.items.map((pokemon, index) => (
        <li key={index}>{pokemon?.name}</li>
      ))}
    </ul>
  );
}
