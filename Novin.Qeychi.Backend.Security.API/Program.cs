using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Novin.Qeychi.Backend.API.Infrastructure;
using Novin.Qeychi.Backend.Core.Entities;
using Novin.Qeychi.Backend.Infrastructure.Database;
using Novin.Qeychi.Backend.Security.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
AppConfiguration.AddServices(builder);
var app = builder.Build();
AppConfiguration.UseServices(app);

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
        var claims = new[]
        {
            new Claim("Username",result.MobileNumber.ToString()),
            new Claim("Name",result.Name.ToString()),
            new Claim("AccessLevel", result.AccessLevel.ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""));
        var signIn=new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            builder.Configuration["Jwt:Issuer"],
            builder.Configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: signIn);

        return new
        {
            IsOk = true,
            Message=result.AccessLevel,
            Token=new JwtSecurityTokenHandler().WriteToken(token)
        };
    }
    return new
    {
        IsOk = false,
        Message = "کاربر مورد نظر یافت نشد.",
        Token=""
    };
});

app.MapPost("/publicLogin", (QeychiDB db) =>
{

});

app.Run();

