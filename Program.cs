using Bible_Search.Data;
using Bible_Search.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BibleDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("BibleDb"), 
        new MySqlServerVersion(new Version(8, 0, 30))));
builder.Services.AddScoped<IBibleRepository, BibleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Bible}/{action=Index}/{id?}");

app.Run();
