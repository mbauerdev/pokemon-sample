using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using PokemonApp.Core;
using PokemonApp.Core.Models;
using PokemonApp.GraphQL.Types;

namespace PokemonApp.GraphQL;

[ExtendObjectType<PokemonPayload>]
public class PokemonTypeExtension
{
    public async Task<PokemonDetailPayload?> GetDetail(
        [Service] PokeApiService pokeApiService,
        [Parent] PokemonPayload pokemonPayload,
        IResolverContext resolverContext,
        CancellationToken cancellationToken) =>
        await GetDetailInternal(
            pokeApiService,
            pokemonPayload.Id.ToString(),
            resolverContext,
            cancellationToken);

    internal static async Task<PokemonDetailPayload?> GetDetailInternal(
        PokeApiService pokeApiService,
        string id,
        IResolverContext resolverContext,
        CancellationToken cancellationToken)
    {
        Pokemon? detail =  await pokeApiService.GetPokemonAsync(id, cancellationToken);

        if (detail is null)
        {
            resolverContext.ReportError(ErrorBuilder.New()
                .SetMessage($"Details not found for Pokémon {id}")
                .SetCode("DETAILS_NOT_FOUND")
                .Build());

            return default;
        }

        return new PokemonDetailPayload(
            detail.BaseExperience,
            detail.Height,
            detail.Order,
            detail.Weight,
            detail.Sprites.BackDefault ?? detail.Sprites.FrontShiny ?? string.Empty,
            detail.Abilities
                .Select(a => a.Ability.Name)
                .ToList(),
            detail.Moves
                .Select(m => m.Move.Name)
                .ToList());
    }
}
