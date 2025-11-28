using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using PokemonApp.Core;
using PokemonApp.Core.Models;

namespace PokemonApp.GraphQL;

[ExtendObjectType(typeof(PokemonDetailPayload))]
public class PokemonDetailPayloadTypeExtension
{
    [BindMember(nameof(PokemonDetailPayload.Abilities))]
    public async Task<List<AbilityPayload>> GetAbilities(
        [Service] PokeApiService pokeApiService,
        [Parent] PokemonDetailPayload detailPayload,
        IResolverContext ctx,
        CancellationToken cancellationToken)
    {
        var results = new List<AbilityPayload>();

        foreach (string abilityRef in detailPayload.Abilities)
        {
            Ability? ability = await pokeApiService.GetAbilities(abilityRef, cancellationToken);
            if (ability is null)
            {
                ctx.ReportError(ErrorBuilder.New()
                    .SetMessage($"Ability details not found for {abilityRef}")
                    .SetCode("ABILITY_NOT_FOUND")
                    .Build());

                continue;
            }

            string shortEffect = ability.EffectEntries.FirstOrDefault(e => e.Language.Name == "en")?.ShortEffect ?? string.Empty;

            results.Add(new AbilityPayload(
                ability.Id,
                ability.Name,
                ability.IsMainSeries,
                shortEffect));
        }

        return results;
    }

    [BindMember(nameof(PokemonDetailPayload.Moves))]
    public async Task<List<MovePayload>> GetMoves(
        [Service] PokeApiService pokeApiService,
        [Parent] PokemonDetailPayload detailPayload,
        IResolverContext ctx,
        CancellationToken cancellationToken)
    {
        var results = new List<MovePayload>();

        foreach (string moveRef in detailPayload.Moves)
        {
            Move? move = await pokeApiService.GetMoves(moveRef, cancellationToken);
            if (move is null)
            {
                ctx.ReportError(ErrorBuilder.New()
                    .SetMessage($"Move details not found for {moveRef}")
                    .SetCode("MOVE_NOT_FOUND")
                    .Build());
                continue;
            }

            results.Add(new MovePayload(
                move.Id,
                move.Name,
                move.Power,
                move.Accuracy,
                move.Type.Name));
        }

        return results;
    }
}
