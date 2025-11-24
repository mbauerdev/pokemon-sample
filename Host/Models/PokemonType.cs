namespace PokemonApp.Host.Models;

public class Type
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<TypeName> Names { get; set; } = new();
    public List<TypePokemon> Pokemon { get; set; } = new();
    public List<NamedAPIResource> Moves { get; set; } = new();
    public NamedAPIResource Generation { get; set; } = new();
    public TypeRelations DamageRelations { get; set; } = new();
}

public class TypeName
{
    public string Name { get; set; } = string.Empty;
    public NamedAPIResource Language { get; set; } = new();
}

public class TypePokemon
{
    public int Slot { get; set; }
    public NamedAPIResource Pokemon { get; set; } = new();
}

public class TypeRelations
{
    public List<NamedAPIResource> NoDamageTo { get; set; } = new();
    public List<NamedAPIResource> HalfDamageTo { get; set; } = new();
    public List<NamedAPIResource> DoubleDamageTo { get; set; } = new();
    public List<NamedAPIResource> NoDamageFrom { get; set; } = new();
    public List<NamedAPIResource> HalfDamageFrom { get; set; } = new();
    public List<NamedAPIResource> DoubleDamageFrom { get; set; } = new();
}
