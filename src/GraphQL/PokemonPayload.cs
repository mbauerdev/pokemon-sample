namespace PokemonApp.GraphQL;

public record PokemonPayload(
    int Id,
    string Name,
    int BaseExperience,
    int Height,
    int Order,
    int Weight,
    string SpriteUrl,
    List<string> Abilities,
    List<string> Moves)
    : PokemonDetailPayload(
        BaseExperience,
        Height,
        Order,
        Weight,
        SpriteUrl,
        Abilities,
        Moves);
