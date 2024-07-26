using System.Data;
using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints;

public static class GamesEndpoints
{
const string GetGameEndpointName = "GetGame";


public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
{

var group = app.MapGroup("games").WithParameterValidation();

// GET /games
group.MapGet("/",async (GameStoreContex dbContext)=> 
           await dbContext.Games
                        .Include(game => game.Genre)
                        .Select(game => game.ToGameSummaryDto())
                        .AsNoTracking()
                        .ToListAsync());

// GET /games/1
group.MapGet("/{ID}",async (int ID,GameStoreContex dbContext) => 
{
    Game? game = await dbContext.Games.FindAsync(ID);

    return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
})
.WithName(GetGameEndpointName);

// POST /games
group.MapPost("/",async (CreateGameDto newGame,GameStoreContex dbContext)=>
{

    Game game = newGame.ToEntity();

    dbContext.Games.Add(game);
    await dbContext.SaveChangesAsync();


    return Results.CreatedAtRoute(
        GetGameEndpointName,
        new {id = game.Id}, 
        game.ToGameDetailsDto()
    );

});

// PUT /games
group.MapPut("/{ID}",async (int ID,UpdateGameDto updatedGame, GameStoreContex dbContext)=>
{
    var existingGame = await dbContext.Games.FindAsync(ID);

    if(existingGame is null)
    {
        return Results.NotFound();
    }

    dbContext.Entry(existingGame)
            .CurrentValues
            .SetValues(updatedGame.ToEntity(ID));

    await dbContext.SaveChangesAsync();

    return Results.NoContent();
});

// DELET /games/1
group.MapDelete("/{ID}",async (int ID,GameStoreContex dbContext) =>
{
    await dbContext.Games
             .Where(game => game.Id == ID)
             .ExecuteDeleteAsync();

    return Results.NoContent();
});
return group;
}
}
