namespace GameStore.Api.Dtos;

public record class GameDto(int Id, string Name, string Genre, DateOnly ReleaseDate, decimal Price);
