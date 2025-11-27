using System.Text.Json;
using System.Text.Json.Serialization;
using PokemonApp.Host.Models;

namespace PokemonApp.Host.Services;

public class PokeApiService(HttpClient httpClient, ILogger<PokeApiService> logger)
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public async Task<Pokemon?> GetPokemonAsync(
        string nameOrId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync($"pokemon/{nameOrId.ToLower()}", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                logger.LogWarning("Failed to fetch PokemonPayload {NameOrId}. Status: {StatusCode}", nameOrId, response.StatusCode);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            return JsonSerializer.Deserialize<Pokemon>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching PokemonPayload {NameOrId}", nameOrId);
            throw;
        }
    }

    public async Task<NamedAPIResourceList?> GetPokemonListAsync(
        int limit = 20,
        int offset = 0,
        CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync($"pokemon?limit={limit}&offset={offset}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<NamedAPIResourceList>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching PokemonPayload list");
            throw;
        }
    }

    /// <summary>
    /// Get an Ability by ID or name
    /// </summary>
    public async Task<Ability?> GetAbilities(string nameOrId, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync($"ability/{nameOrId.ToLower()}", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                logger.LogWarning("Failed to fetch Ability {NameOrId}. Status: {StatusCode}", nameOrId, response.StatusCode);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<Ability>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching Ability {NameOrId}", nameOrId);
            throw;
        }
    }

    /// <summary>
    /// Get a list of Abilities with pagination
    /// </summary>
    public async Task<NamedAPIResourceList?> GetAbilityListAsync(int limit = 20, int offset = 0, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync($"ability?limit={limit}&offset={offset}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<NamedAPIResourceList>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching Ability list");
            throw;
        }
    }

    /// <summary>
    /// Get a Move by ID or name
    /// </summary>
    public async Task<Move?> GetMoves(string nameOrId, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync($"move/{nameOrId.ToLower()}", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                logger.LogWarning("Failed to fetch Move {NameOrId}. Status: {StatusCode}", nameOrId, response.StatusCode);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<Move>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching Move {NameOrId}", nameOrId);
            throw;
        }
    }

    /// <summary>
    /// Get a list of Moves with pagination
    /// </summary>
    public async Task<NamedAPIResourceList?> GetMoveListAsync(int limit = 20, int offset = 0, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync($"move?limit={limit}&offset={offset}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<NamedAPIResourceList>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching Move list");
            throw;
        }
    }

    /// <summary>
    /// Get a Type by ID or name
    /// </summary>
    public async Task<Models.Type?> GetTypeAsync(string nameOrId, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync($"type/{nameOrId.ToLower()}", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                logger.LogWarning("Failed to fetch Type {NameOrId}. Status: {StatusCode}", nameOrId, response.StatusCode);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<Models.Type>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching Type {NameOrId}", nameOrId);
            throw;
        }
    }

    /// <summary>
    /// Get a list of Types with pagination
    /// </summary>
    public async Task<NamedAPIResourceList?> GetTypeListAsync(int limit = 20, int offset = 0, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync($"type?limit={limit}&offset={offset}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<NamedAPIResourceList>(content, JsonOptions);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching Type list");
            throw;
        }
    }
}
