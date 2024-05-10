using KPACodingProject.Data;
using KPACodingProject.Entities;
using KPACodingProject.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddDbContext<AirlinesContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("AirlinesContext")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUploadJsonFileHandler, UploadJsonFileHandler>();
builder.Services.AddTransient<IAirportDA, AirportDA>();
builder.Services.AddTransient<IGetAirportDataHandler, GetAirportDataHandler>();
builder.Services.AddTransient<IUpdateAirlineHandler, UpdateAirlineHandler>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("airportDataPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();

app.Run();