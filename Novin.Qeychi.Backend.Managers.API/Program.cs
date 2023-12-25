using Novin.Qeychi.Backend.API.Infrastructure;
using Novin.Qeychi.Backend.Infrastructure.Database;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
AppConfiguration.AddServices(builder);
var app = builder.Build();
AppConfiguration.UseServices(app);

app.MapPost("/adminList", (QeychiDB db, ClaimsPrincipal user) =>
{
    var result = user.Claims.FirstOrDefault(c => c.Type == "AccessLevel")?.Value;
    if (result == "management")
    {
        return db.Managers.ToList();
    }
    return null;
}).RequireAuthorization();

app.Run();

