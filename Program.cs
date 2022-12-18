using System.Diagnostics;
using CarShowRoom.DbModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// добавляем контекст БД
string dbName = builder.Configuration.GetSection("Database").Value;
switch (dbName)
{
    case "SQLServer":
        string connection = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<CarDbContext>(options => options.UseSqlServer(connection));
        break;
    case "PostgreSQL":
        string connection2 = builder.Configuration.GetConnectionString("psql");
        builder.Services.AddDbContext<CarDbContext>(options => options.UseNpgsql(connection2));
        break;
    default:
        throw new Exception("bad DBName");
}
//добавляем аутентификацию и авторизацию на основе cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
    });
builder.Services.AddAuthorization();
//настройка web сервера 
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();