using Microsoft.EntityFrameworkCore;

using StudentApp.Models;
using StudentApp.Repo;
using StudentApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ? Register DbContext with connection string
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? Dependency Injection (Repository + Service)
builder.Services.AddScoped<IStudentRepo,StudentRepo>();
builder.Services.AddScoped<IStudentSevice,StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ? Default route to Student Controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
