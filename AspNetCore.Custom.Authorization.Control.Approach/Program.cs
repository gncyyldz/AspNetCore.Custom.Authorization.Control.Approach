using AspNetCore.Custom.Authorization.Control.Approach.AuthorizationHandlers;
using AspNetCore.Custom.Authorization.Control.Approach.AuthorizationRequirements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("TimeControl", policy => policy.Requirements.Add(new TimeRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler, TimeHandler>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
