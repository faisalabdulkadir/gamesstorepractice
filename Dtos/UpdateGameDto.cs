namespace GameStore.Api.Dtos;

public record class UpdateGameDto(string Name, string Genre, DateOnly ReleaseDate, decimal Price);
