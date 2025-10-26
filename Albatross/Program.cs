
//Original:
//using Microsoft.EntityFrameworkCore;
//using Albatross.Models;

using Microsoft.EntityFrameworkCore;
using Albatross.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DB-CONNECTION
builder.Services.AddDbContext<ItemDbContext>(options => {
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:ItemDbContextConnection"]);
});

//Setting up user authentication and identity management
builder.Services.AddDefaultIdentity<User>(options => 
{
    //doesnt require email confirmation
    options.SignIn.RequireConfirmedAccount = false;
    //but requires unique email for users
    options.User.RequireUniqueEmail = true;

    //password requirements, false for simplicity of MVP
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;

    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ItemDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    DBInit.Seed(app);
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

/* Kommenteres ut ved bruk av seed / DBINIT
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

app.Run();


/* Fra alabtross 2:

using Microsoft.EntityFrameworkCore;
using Albatross.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ItemDbContext>(options => {
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:ItemDbContextConnection"]);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())

{
    app.UseDeveloperExceptionPage();
    /*DBInit.Seed(app);
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
*/