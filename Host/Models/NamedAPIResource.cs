namespace PokemonApp.Host.Models;

/// <summary>
/// Represents a reference to another resource with a name and URL
/// </summary>
public class NamedAPIResource
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}

/// <summary>
/// Paginated list response from the API
/// </summary>
public class NamedAPIResourceList
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public List<NamedAPIResource> Results { get; set; } = new();
}
