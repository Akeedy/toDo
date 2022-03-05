using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddDbContext<Context>(config =>
    config.UseNpgsql("User ID=orhan;Password=12345;Server=localhost;Port=5432;Database=todo;Integrated Security=true;Pooling=true;"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(config =>
    {
        config.Password.RequiredLength = 5;
        config.Password.RequireDigit = false;
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireUppercase = false;
    })
.AddEntityFrameworkStores<Context>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "Identity";
    config.LoginPath = "/User/Register";
});
// builder.Services.AddAuthentication("CookieAuth")
//     .AddCookie("CookieAuth", config =>
//     {
//         config.Cookie.Name = "BasicCookie";
//         config.LoginPath = "/User/Register";
//     });
// builder.Services.AddHttpContextAccessor();


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

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
