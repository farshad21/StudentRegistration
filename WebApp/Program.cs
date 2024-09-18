// WebApp/Program.cs
using Microsoft.OpenApi.Models;
using Service.Interface;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);

// اضافه کردن سرویس‌های Swagger به DI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student Management API", Version = "v1" });
});

// اضافه کردن سرویس‌های لایه Service به DI
builder.Services.AddScoped<IStudentService, StudentService>();

// اضافه کردن MVC به برنامه
builder.Services.AddControllersWithViews();

var app = builder.Build();


// پیکربندی Swagger و SwaggerUI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Management API v1");
        c.RoutePrefix = string.Empty; // برای دسترسی به Swagger در مسیر ریشه
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
