using PokemonApp.Core.Models;

namespace PokemonApp.GraphQL;

public static class ConversionExtensions
{
    extension(Pokemon pokemon)
    {
        public PokemonPayload ToPokemonPayload() =>
            new(
                pokemon.Id,
                pokemon.Name,
                pokemon.BaseExperience,
                pokemon.Height,
                pokemon.Order,
                pokemon.Weight,
                pokemon.Sprites.BackDefault ?? pokemon.Sprites.FrontShiny ?? string.Empty,
                pokemon.Abilities
                    .Select(a => a.Ability.Name)
                    .ToList(),
                pokemon.Moves
                    .Select(m => m.Move.Name)
                    .ToList());


        public PokemonDetailPayload ToPokemonDetailPayload() =>
            new(
                pokemon.BaseExperience,
                pokemon.Height,
                pokemon.Order,
                pokemon.Weight,
                pokemon.Sprites.BackDefault ?? pokemon.Sprites.FrontShiny ?? string.Empty,
                pokemon.Abilities
                    .Select(a => a.Ability.Name)
                    .ToList(),
                pokemon.Moves
                    .Select(m => m.Move.Name)
                    .ToList());
    }
}
