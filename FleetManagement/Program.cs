using Backend.Data;
using FleetManagementAPI.Repositories.IRepositories;
using FleetManagementAPI.Repositories.Repositories;
using Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext в контейнер зависимостей
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация других сервисов
builder.Services.AddTransient<IGPSMobileReceive, GPSMobileReceive>();

// Добавляем контроллеры с представлениями
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

// Регистрация сервисов как Scoped
builder.Services.AddScoped<DeviceHub>();


var app = builder.Build();

// Конфигурация pipeline
app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<DeviceHub>("/hubs/DeviceHub");

// Получаем зависимость и вызываем настройку подписки

app.Run();
