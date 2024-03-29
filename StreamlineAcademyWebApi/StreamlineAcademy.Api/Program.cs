using StreamlineAcademy.Application.DI;
using StreamlineAcademy.Infrastructure.DI;
using StreamlineAcademy.Persistence.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Validate the server & Generate the Token
        ValidateAudience = true,//Validate the recipient of the token is authorized to receive
        ValidateLifetime = true,//Check if the token is not expired and the signing key of the issuer is valid
        ValidateIssuerSigningKey = true,//Validate signature of the token 
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt.Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))


    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding Services added inside AddPersistenceService Etension Method
builder.Services.AddPersistenceService(builder.Configuration)
               .AddAplicationService(builder.Environment.WebRootPath)
               .AddInfrastructureService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
