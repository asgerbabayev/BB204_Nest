using BB204_Nest_Web_App.DAL;
using BB204_Nest_Web_App.Models;
using BB204_Nest_Web_App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
});



builder.Services.AddScoped<LayoutService>();

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromSeconds(5);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );
});

app.MapDefaultControllerRoute();

app.Run();
