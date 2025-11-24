using PokemonApp.Host.Models;
using PokemonApp.Host.Services;

namespace PokemonApp.Host.GraphQL;

public class Query
{
    public async Task<Pokemon?> GetPokemon(
        string nameOrId,
        [Service] PokeApiService pokeApiService,
        CancellationToken cancellationToken)
    {
        return await pokeApiService.GetPokemonAsync(nameOrId, cancellationToken);
    }

    public async Task<PokemonConnection> GetPokemons(
        [Service] PokeApiService pokeApiService,
        CancellationToken cancellationToken,
        int first = 20,
        int offset = 0)
    {
        NamedAPIResourceList? list = await pokeApiService.GetPokemonListAsync(first, offset, cancellationToken);

        return new PokemonConnection
        {
            TotalCount = list?.Count ?? 0,
            Edges = list?.Results.Select(r => new PokemonEdge
            {
                Node = new NamedAPIResource { Name = r.Name, Url = r.Url }
            }).ToList() ?? new List<PokemonEdge>(),
            PageInfo = new PageInfo
            {
                HasNextPage = list?.Next != null,
                HasPreviousPage = list?.Previous != null
            }
        };
    }
}

// Connection types for pagination
public class PokemonConnection
{
    public int TotalCount { get; set; }
    public List<PokemonEdge> Edges { get; set; } = new();
    public PageInfo PageInfo { get; set; } = new();
}

public class PokemonEdge
{
    public NamedAPIResource Node { get; set; } = new();
}

public class AbilityConnection
{
    public int TotalCount { get; set; }
    public List<AbilityEdge> Edges { get; set; } = new();
    public PageInfo PageInfo { get; set; } = new();
}

public class AbilityEdge
{
    public NamedAPIResource Node { get; set; } = new();
}

public class MoveConnection
{
    public int TotalCount { get; set; }
    public List<MoveEdge> Edges { get; set; } = new();
    public PageInfo PageInfo { get; set; } = new();
}

public class MoveEdge
{
    public NamedAPIResource Node { get; set; } = new();
}

public class TypeConnection
{
    public int TotalCount { get; set; }
    public List<TypeEdge> Edges { get; set; } = new();
    public PageInfo PageInfo { get; set; } = new();
}

public class TypeEdge
{
    public NamedAPIResource Node { get; set; } = new();
}

public class PageInfo
{
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
}
