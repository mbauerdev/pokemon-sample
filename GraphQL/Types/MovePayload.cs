namespace PokemonApp.GraphQL.Types;

public record MovePayload(
    int Id,
    string Name,
    int? Power,
    int? Accuracy,
    string TypeName);
