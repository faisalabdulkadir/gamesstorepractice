using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new(1, "The Legend of Zelda: Tears of the Kingdom", "Action-Adventure",new DateOnly(2023,5,12), 59.99M),
    new(2,"Elden Ring", "RPG", new DateOnly(2022, 2, 25), 59.99M),
    new(3, "Minecraft","Sandbox", new DateOnly(2011, 11, 18), 26.95M),
    new(4, "Red Dead Redemption 2", "Action-Adventure", new DateOnly(2018, 10,26), 59.99M),
    new(5, "Cyberpunk 2077", "RPG", new DateOnly(2020, 12, 10), 59.99M),
    new(6, "Fortnite","Battle Royale", new DateOnly(2017, 9, 26), 30.99M)

];

//Get all games: games
app.MapGet("games", () => games);

//Get single game: games/1
app.MapGet("games/{id}", (int id) =>
{
    GameDto? game = games.Find(game => game.Id == id);
    return game is null ? Results.NotFound() : Results.Ok(game);
}).WithName(GetGameEndpointName);

//Post games
app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.ReleaseDate, newGame.Price);
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

//Put games/1
app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);
    if (index == -1)
    {
        return Results.NotFound();
    }
    games[index] = new GameDto(id, updatedGame.Name, updatedGame.Genre, updatedGame.ReleaseDate, updatedGame.Price);

    return Results.NoContent();
});

//Delete games/1
app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
});

app.Run();

// [
//   {
//     "id": 7,
//     "name": "Call of Duty: Modern Warfare II",
//     "genre": "FPS",
//     "releasedate": "October 28, 2022",
//     "price": "$69.99"
//   },
//   {
//     "id": 8,
//     "name": "Animal Crossing: New Horizons",
//     "genre": "Simulation",
//     "releasedate": "March 20, 2020",
//     "price": "$59.99"
//   },
//   {
//     "id": 9,
//     "name": "Assassin's Creed Valhalla",
//     "genre": "Action RPG",
//     "releasedate": "November 10, 2020",
//     "price": "$59.99"
//   },
//   {
//     "id": 10,
//     "name": "Overwatch 2",
//     "genre": "FPS",
//     "releasedate": "October 4, 2022",
//     "price": "Free-to-play"
//   }
// ]

