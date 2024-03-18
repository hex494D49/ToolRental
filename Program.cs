using Microsoft.EntityFrameworkCore;
using ToolRental.Application.Interfaces;
using ToolRental.Application.Services;
using ToolRental.Infrastructure;
using ToolRental.Infrastructure.Interfaces;
using ToolRental.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddScoped<IToolRepository, ToolRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
