using GameStore.API.Data;
using GameStore.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContex>(connectString);

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndpoints();

await app.MigrateDbAsync();

app.Run();

