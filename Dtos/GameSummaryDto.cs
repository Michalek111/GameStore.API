namespace GameStore.API.Dtos;

public record class GameSummaryDto(
    int ID, 
    string Name,
    string Genre, 
    decimal Price,
    DateOnly ReleaseDate
    );

