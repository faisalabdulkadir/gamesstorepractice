namespace GameStore.Api.Dtos;

public record class CreateGameDto(string Name, string Genre, DateOnly ReleaseDate, decimal Price);
