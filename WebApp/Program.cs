// WebApp/Program.cs
using Service.Interface;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);

// اضافه کردن سرویس‌های لایه Service به DI
builder.Services.AddScoped<IStudentService, StudentService>();

// اضافه کردن MVC به برنامه
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
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
