using PokemonApp.Core;
using PokemonApp.GraphQL;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add HttpClient for PokeAPI
builder.Services.AddHttpClient<PokeApiService>(client =>
{
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
});

// Add GraphQL Services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<PokemonCollectionPayloadTypeExtension>()
    .AddTypeExtension<PokemonDetailPayloadTypeExtension>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

WebApplication app = builder.Build();

app.MapGraphQL();

app.Run();

