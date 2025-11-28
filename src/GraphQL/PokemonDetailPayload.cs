namespace PokemonApp.GraphQL;

public record PokemonDetailPayload(
    int BaseExperience,
    int Height,
    int Order,
    int Weight,
    string SpriteUrl,
    List<string> Abilities,
    List<string> Moves);
