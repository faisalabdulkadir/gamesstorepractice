using GameStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGamesEndPoints();

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

