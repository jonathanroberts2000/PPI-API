using PPI_Core;
using System.Text;
using PPI_Core.Rules;
using PPI_API.UnitOfWork;
using PPI_API.Middleware;
using PPI_Core.Services.Auth;
using PPI_Core.Services.Asset;
using PPI_Core.Services.Order;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using PPI_API.UnitOfWork.Repositories.Order;
using PPI_API.UnitOfWork.Repositories.Asset;
using PPI_Data.UnitOfWork.Repositories.Rule;
using PPI_Data.UnitOfWork.Repositories.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

builder.Configuration.AddJsonFile($"Config/connectionString.{builder.Environment.EnvironmentName}.json");
builder.Configuration.AddJsonFile($"Config/jwt.{builder.Environment.EnvironmentName}.json");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IAssetRepository, AssetRepository>();
builder.Services.AddTransient<IRuleRepository, RuleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddSingleton<Globals>();
builder.Services.AddHostedService<Globals>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IAssetService, AssetService>();
builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddSingleton<IRulesManager, RulesManager>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "PPI-API",
        ValidAudience = "PPI-API",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(opt => opt.EnableAnnotations());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }