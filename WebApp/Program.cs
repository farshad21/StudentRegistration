// WebApp/Program.cs
using DataAccess.DataContext;
using DataAccess.Interface;
using DataAccess.Repositories;
using Microsoft.OpenApi.Models;
using Service.Interface;
using Service.Service;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 1. اضافه کردن سرویس‌های MVC
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();

// 2. تنظیمات Connection String برای DapperDbContext
builder.Services.AddSingleton<DapperDbContext>();

// 3. ثبت Repository و Service ها در DI
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();


// 4. تنظیمات Swagger برای مستندسازی API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Student Management API",
        Version = "v1",
        Description = "API Documentation for Student Management System"
    });
});

var app = builder.Build();


// 5. پیکربندی Middleware ها و Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Management API v1");
        c.RoutePrefix = string.Empty; // دسترسی به Swagger در ریشه
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 6. Middleware های ضروری
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 7. تنظیم مسیر پیش‌فرض برای کنترلرها
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
