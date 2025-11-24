namespace PokemonApp.Host.Models;

public class Ability
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsMainSeries { get; set; }
    public NamedAPIResource Generation { get; set; } = new();
    public List<AbilityName> Names { get; set; } = new();
    public List<AbilityEffectEntry> EffectEntries { get; set; } = new();
    public List<AbilityFlavorTextEntry> FlavorTextEntries { get; set; } = new();
    public List<AbilityPokemon> Pokemon { get; set; } = new();
}

public class AbilityName
{
    public string Name { get; set; } = string.Empty;
    public NamedAPIResource Language { get; set; } = new();
}

public class AbilityEffectEntry
{
    public string Effect { get; set; } = string.Empty;
    public string ShortEffect { get; set; } = string.Empty;
    public NamedAPIResource Language { get; set; } = new();
}

public class AbilityFlavorTextEntry
{
    public string FlavorText { get; set; } = string.Empty;
    public NamedAPIResource Language { get; set; } = new();
    public NamedAPIResource VersionGroup { get; set; } = new();
}

public class AbilityPokemon
{
    public bool IsHidden { get; set; }
    public int Slot { get; set; }
    public NamedAPIResource Pokemon { get; set; } = new();
}
