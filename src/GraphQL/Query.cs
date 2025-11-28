using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using PokemonApp.Core;
using PokemonApp.Core.Models;

namespace PokemonApp.GraphQL;

public class Query
{
    [UseOffsetPaging]
    public async Task<CollectionSegment<PokemonCollectionPayload>> GetPokemons(
        [Service] PokeApiService pokeApiService,
        int skip,
        int take,
        CancellationToken cancellationToken)
    {
        NamedAPIResourceList result = await pokeApiService.GetPokemonListAsync(
            take,
            skip,
            cancellationToken) ?? new NamedAPIResourceList();

        var pageInfo = new CollectionSegmentInfo(
            result.Next is not null,
            result.Previous is not null);

        var collectionSegment = new CollectionSegment<PokemonCollectionPayload>(
            result.Results
                .Select(r => new PokemonCollectionPayload(
                    int.Parse(new Uri(r.Url).Segments.Last().TrimEnd("/")),
                    r.Name))
                .ToList(),
            pageInfo,
            result.Count);

        return collectionSegment;
    }

    public async Task<PokemonPayload?> GetPokemon(
        [Service] PokeApiService pokeApiService,
        PokemonInput input,
        CancellationToken cancellationToken,
        IResolverContext resolverContext)
    {
        string id = input.Id.ToString();

        Pokemon? result = await pokeApiService.GetPokemonAsync(
            id,
            cancellationToken);

        if (result is null)
        {
            resolverContext.ReportError(ErrorBuilder.New()
                .SetMessage($"Details not found for Pokémon {id}")
                .SetCode("DETAILS_NOT_FOUND")
                .Build());

            return default;
        }

        return result.ToPokemonPayload();
    }
}
