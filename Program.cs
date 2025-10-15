using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectPartB.Areas.Identity.Data;
using ProjectPartB.Models;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'CustomIdentityContextConnection' not found.");

builder.Services.AddDbContext<CustomIdentityContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<FS23_Group4_ProjectContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<WebUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CustomIdentityContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
var services = builder.Services;
var configuration = builder.Configuration;
services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});
// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // Set session options here
    options.IdleTimeout = TimeSpan.FromMinutes(30); // e.g. 30 minutes
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseStaticFiles();

// Use session middleware here
app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
