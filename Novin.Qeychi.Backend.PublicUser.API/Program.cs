using Novin.Qeychi.Backend.API.Infrastructure;
using Novin.Qeychi.Backend.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
AppConfiguration.AddServices(builder);
var app = builder.Build();
AppConfiguration.UseServices(app);

app.MapPost("/BeautySalonList", (QeychiDB db) =>
{
    return db.BeautySalons.ToList();
});

app.Run();

