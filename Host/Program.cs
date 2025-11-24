using PokemonApp.Host.GraphQL;
using PokemonApp.Host.Services;

var builder = WebApplication.CreateBuilder(args);

// Add HttpClient for PokeAPI
builder.Services.AddHttpClient<PokeApiService>(client =>
{
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
});

// Add GraphQL Services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

app.MapGraphQL();

app.Run();

