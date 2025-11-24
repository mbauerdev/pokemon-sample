namespace PokemonApp.Host.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int BaseExperience { get; set; }
    public int Height { get; set; }
    public bool IsDefault { get; set; }
    public int Order { get; set; }
    public int Weight { get; set; }
    public List<PokemonAbility> Abilities { get; set; } = new();
    public List<PokemonType> Types { get; set; } = new();
    public List<PokemonStat> Stats { get; set; } = new();
    public List<PokemonMove> Moves { get; set; } = new();
    public PokemonSprites Sprites { get; set; } = new();
    public NamedAPIResource Species { get; set; } = new();
}

public class PokemonAbility
{
    public bool IsHidden { get; set; }
    public int Slot { get; set; }
    public NamedAPIResource Ability { get; set; } = new();
}

public class PokemonType
{
    public int Slot { get; set; }
    public NamedAPIResource Type { get; set; } = new();
}

public class PokemonStat
{
    public int BaseStat { get; set; }
    public int Effort { get; set; }
    public NamedAPIResource Stat { get; set; } = new();
}

public class PokemonMove
{
    public NamedAPIResource Move { get; set; } = new();
    public List<VersionGroupDetail> VersionGroupDetails { get; set; } = new();
}

public class VersionGroupDetail
{
    public int LevelLearnedAt { get; set; }
    public NamedAPIResource MoveLearnMethod { get; set; } = new();
    public NamedAPIResource VersionGroup { get; set; } = new();
}

public class PokemonSprites
{
    public string? FrontDefault { get; set; }
    public string? FrontShiny { get; set; }
    public string? FrontFemale { get; set; }
    public string? FrontShinyFemale { get; set; }
    public string? BackDefault { get; set; }
    public string? BackShiny { get; set; }
    public string? BackFemale { get; set; }
    public string? BackShinyFemale { get; set; }
    public SpritesOther? Other { get; set; }
}

public class SpritesOther
{
    public DreamWorld? DreamWorld { get; set; }
    public Home? Home { get; set; }
    public OfficialArtwork? OfficialArtwork { get; set; }
}

public class DreamWorld
{
    public string? FrontDefault { get; set; }
    public string? FrontFemale { get; set; }
}

public class Home
{
    public string? FrontDefault { get; set; }
    public string? FrontFemale { get; set; }
    public string? FrontShiny { get; set; }
    public string? FrontShinyFemale { get; set; }
}

public class OfficialArtwork
{
    public string? FrontDefault { get; set; }
    public string? FrontShiny { get; set; }
}
