using Novin.Qeychi.Backend.API.Infrastructure;
using Novin.Qeychi.Backend.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
AppConfiguration.AddServices(builder);
var app = builder.Build();
AppConfiguration.UseServices(app);

app.MapPost("/publicLogin", (QeychiDB db) =>
{
    return db.Customers.ToList();
});

app.Run();

