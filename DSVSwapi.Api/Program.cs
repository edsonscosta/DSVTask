using System.Globalization;
using DSVSwapi.Repository;
using DSVSwapi.Repository.Domain.DTOs;
using DSVSwapi.Repository.Model;
using DSVSwapi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
 

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPlanetService, PlanetService>();
builder.Services.AddTransient<IResidentService, ResidentService>(); 

builder.Services.AddDbContext<DSVSwapiDBContext>(options => 
    options.UseSqlServer(
        "Data Source=localhost,1433;Initial Catalog=DSVSwapiApi;Persist Security Info=True;User ID=sa;Password=DSVSwapiApi@123; MultipleActiveResultSets=True;TrustServerCertificate=True")
    );

builder.Services.AddScoped<IRepository<PlanetDTO>, PlanetRepository>();
builder.Services.AddScoped<IRepository<ResidentDTO>, ResidentRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();
app.MapControllers();


app.Run();