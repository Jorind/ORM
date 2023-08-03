using HelloEF;
using HelloEF.DefaultData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol;

var builder = WebApplication.CreateBuilder(args);

var connectionString 
    = builder.Configuration.GetConnectionString("AppDb");

//ef-related configs
builder.Services.AddDbContextPool<SchoolContext>(x => x
     .UseLazyLoadingProxies()
     .UseSqlServer(connectionString)
     .UseLoggerFactory(LoggerFactory.Create(builder=>builder.AddConsole())));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

//ef-related configs
try
{
    var context = services.GetRequiredService<SchoolContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (System.Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
