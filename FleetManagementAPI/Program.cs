using Backend.Data;
using FleetManagementAPI.Models;
using FleetManagementAPI.Repositories.IRepositories;
using FleetManagementAPI.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<GPSMobileReceive>();
builder.Services.AddScoped<IGPSMobileReceive, GPSMobileReceive>();


builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Configure Kestrel to listen only on the HTTP port
builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(8090); // HTTP ����
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/devices", async (DataContext data) => await data.DeviceLocations.ToListAsync());

app.MapPost("/devices", async (DeviceLocation device, DataContext data) =>
{
    data.DeviceLocations.Add(device);
    await data.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
