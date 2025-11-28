using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using PokemonApp.Core;
using PokemonApp.Core.Models;

namespace PokemonApp.GraphQL;

[ExtendObjectType<PokemonCollectionPayload>]
public class PokemonCollectionPayloadTypeExtension
{
    public async Task<PokemonDetailPayload?> GetDetail(
        [Service] PokeApiService pokeApiService,
        [Parent] PokemonCollectionPayload pokemonPayload,
        IResolverContext resolverContext,
        CancellationToken cancellationToken)
    {
        string id = pokemonPayload.Id.ToString();

        Pokemon? result =  await pokeApiService.GetPokemonAsync(id, cancellationToken);

        if (result is null)
        {
            resolverContext.ReportError(ErrorBuilder.New()
                .SetMessage($"Details not found for Pokémon {id}")
                .SetCode("DETAILS_NOT_FOUND")
                .Build());

            return default;
        }

        return result.ToPokemonDetailPayload();
    }
}
