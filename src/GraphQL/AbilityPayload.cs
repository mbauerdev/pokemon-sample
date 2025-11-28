namespace PokemonApp.GraphQL;

public record AbilityPayload(
    int Id,
    string Name,
    bool IsMainSeries,
    string ShortEffect);
