using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record class UpdateGameDto(
    [Required][StringLength(50)] string Name,
    int GenreID, 
    [Range(1,500)] decimal Price,
    DateOnly ReleaseDate
);

