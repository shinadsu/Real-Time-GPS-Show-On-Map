using Backend.Data;
using FleetManagementAPI.Repositories.IRepositories;
using FleetManagementAPI.Repositories.Repositories;
using Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ��������� DbContext � ��������� ������������
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ����������� ������ ��������
builder.Services.AddTransient<IGPSMobileReceive, GPSMobileReceive>();

// ��������� ����������� � ���������������
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

// ����������� �������� ��� Scoped
builder.Services.AddScoped<DeviceHub>();


var app = builder.Build();

// ������������ pipeline
app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<DeviceHub>("/hubs/DeviceHub");

// �������� ����������� � �������� ��������� ��������

app.Run();
