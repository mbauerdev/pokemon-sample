using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using PokemonApp.Core;
using PokemonApp.Core.Models;
using PokemonApp.GraphQL.Types;

namespace PokemonApp.GraphQL;

public class Query
{
    [UseOffsetPaging]
    public async Task<CollectionSegment<PokemonPayload>> GetPokemons(
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

        var collectionSegment = new CollectionSegment<PokemonPayload>(
            result.Results
                .Select(r => new PokemonPayload(
                    int.Parse(new Uri(r.Url).Segments.Last().TrimEnd("/")),
                    r.Name))
                .ToList(),
            pageInfo,
            result.Count);

        return collectionSegment;
    }

    public Task<PokemonDetailPayload?> GetPokemon(
        [Service] PokeApiService pokeApiService,
        PokemonInput input,
        CancellationToken cancellationToken,
        IResolverContext resolverContext) =>
        PokemonTypeExtension.GetDetailInternal(
            pokeApiService,
            input.Id.ToString(),
            resolverContext,
            cancellationToken);
}
