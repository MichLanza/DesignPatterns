using DesignPatterns.Models.Entities;
using DesignPatterns.MVC.Config;
using Microsoft.EntityFrameworkCore;
using Repository;
using Tools.Earn;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<ProjectConfig>(builder.Configuration.GetSection("Config"));

builder.Services.AddTransient((factory) =>
{
    return new LocalEarnFactory(0.20m);
});

builder.Services.AddTransient((factory) =>
{
    return new ForeignEarnFactory(0.20m, 7.0m);
});

builder.Services.AddDbContext<VideoGameAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VideoGameApp"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
