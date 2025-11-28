namespace PokemonApp.Core.Models;

public class Move
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? Accuracy { get; set; }
    public int? EffectChance { get; set; }
    public int? Pp { get; set; }
    public int Priority { get; set; }
    public int? Power { get; set; }
    public NamedAPIResource DamageClass { get; set; } = new();
    public NamedAPIResource Type { get; set; } = new();
    public NamedAPIResource? Target { get; set; }
    public NamedAPIResource Generation { get; set; } = new();
    public List<MoveName> Names { get; set; } = new();
    public List<MoveFlavorTextEntry> FlavorTextEntries { get; set; } = new();
    public List<MoveEffectEntry> EffectEntries { get; set; } = new();
}

public class MoveName
{
    public string Name { get; set; } = string.Empty;
    public NamedAPIResource Language { get; set; } = new();
}

public class MoveFlavorTextEntry
{
    public string FlavorText { get; set; } = string.Empty;
    public NamedAPIResource Language { get; set; } = new();
    public NamedAPIResource VersionGroup { get; set; } = new();
}

public class MoveEffectEntry
{
    public string Effect { get; set; } = string.Empty;
    public string ShortEffect { get; set; } = string.Empty;
    public NamedAPIResource Language { get; set; } = new();
}
