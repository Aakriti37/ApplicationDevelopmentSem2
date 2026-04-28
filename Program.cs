using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sem2FirstProject.Data;
using Sem2FirstProject.Data.Entities;
using Sem2FirstProject.Middlewares;
using Sem2FirstProject.Models;
using Sem2FirstProject.Services.Implementations;
using Sem2FirstProject.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Sem2FirstProject.Data.Entities.Student>(
    builder.Configuration.GetSection("Student")
    );

builder.Services.AddScoped<IModuleService, ModuleService>();

builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddDbContext<AppDbContext>(

    (options) => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"))

    );

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestLoggerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
