using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using revision_5w5.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAlmostAll", policy =>
    {
        // TODO pour utiliser AllowCredentials, il faut spécifier les origines acceptés
        // on ne peut plus utiliser AllowAnyOrigin
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200");
        //policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        // TODO permettre l'utilisation des Cookies
        policy.AllowCredentials();

    });
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
//builder.Services.AddDefaultIdentity<IdentityUser>();
//builder.Services.AddDefaultIdentity<IdentityUser>()
//    // TODO
//    .AddRoles<IdentityRole>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAlmostAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
