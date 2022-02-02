using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Data;
using System.Reflection;

var seed = args.Contains("/seed");
if (seed)
{
    args = args.Except(new[] { "/seed" }).ToArray();

}

var builder = WebApplication.CreateBuilder(args);



var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
var defaultConnString = builder.Configuration.GetConnectionString("DefaultConnection");

if (seed)
{
    SeedData.EnsureSeedData(defaultConnString);
}
//Add Identity
builder.Services.AddDbContext<AspNetIdentityDbContext>(b => b.UseSqlServer(defaultConnString,
    sql => sql.MigrationsAssembly(migrationsAssembly)));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AspNetIdentityDbContext>();
//builder.Services.AddHealthChecks();

builder.Services.AddIdentityServer(y =>  y.EmitStaticAudienceClaim = false).
    //AddAspNetIdentity<IdentityUser>().
    AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(defaultConnString,
            sql => sql.MigrationsAssembly(migrationsAssembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(defaultConnString,
            sql => sql.MigrationsAssembly(migrationsAssembly));
    }).AddDeveloperSigningCredential();

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endPoints =>
{
    endPoints.MapDefaultControllerRoute();
});

//app.MapGet("/", () => "Hello World!");

app.Run();
