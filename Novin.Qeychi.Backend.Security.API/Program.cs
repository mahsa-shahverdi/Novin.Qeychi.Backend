using Microsoft.EntityFrameworkCore;
using Novin.Qeychi.Backend.Core.Entities;
using Novin.Qeychi.Backend.Infrastructure.Database;
using Novin.Qeychi.Backend.Security.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QeychiDB>(options=>
{
    options.UseSqlServer("Server=(Localdb)\\MSSQLLocalDB;Database=QeychiDB;Trusted_Connection=True");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/adminLogin", (QeychiDB db, AdminLoginRequestDTO adminLogin ) =>
{
    if (!db.Managers.Any())
    {
        var firstAdmin = new Manager
        {
            MobileNumber = "09123456789",
            Name = "admin",
            AccessLevel = "management",
            Password = "admin",
            Email = "admin@gmail.com",
        };
        db.Managers.Add(firstAdmin);
        db.SaveChanges();
    }
    var result=db.Managers
    .Where(m=> m.MobileNumber==adminLogin.Username && m.Password==adminLogin.Password)
    .FirstOrDefault();
    if (result!=null)
    {
        return new
        {
            IsOk = true,
            Message="wellcome"
        };
    }
    return new
    {
        IsOk = false,
        Message = "not found"
    };
});

app.Run();

