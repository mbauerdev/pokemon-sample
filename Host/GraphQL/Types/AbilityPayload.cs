namespace PokemonApp.Host.GraphQL.Types;

public record AbilityPayload(
    int Id,
    string Name,
    bool IsMainSeries,
    string ShortEffect);
