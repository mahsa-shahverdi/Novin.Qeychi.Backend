using Microsoft.EntityFrameworkCore;
using Novin.Qeychi.Backend.Core.Entities;
using Novin.Qeychi.Backend.Infrastructure.Database;
using Novin.Qeychi.Backend.Security.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QeychiDB>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDB"));
});
builder.Services.AddCors(options =>
options.AddDefaultPolicy(builder=> builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

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

