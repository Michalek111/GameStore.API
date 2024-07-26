using GameStore.API.Dtos;
using GameStore.API.Entities;

namespace GameStore.API.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game()
        {
            Name = game.Name,
            GenreID = game.GenreID,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        }; 
    }

     public static Game ToEntity(this UpdateGameDto game, int ID)
    {
        return new Game()
        {
            Id = ID,
            Name = game.Name,
            GenreID = game.GenreID,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        }; 
    }

    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate
        );
    }

    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.GenreID,
            game.Price,
            game.ReleaseDate
        );
    }
}
