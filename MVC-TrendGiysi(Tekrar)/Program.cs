using Microsoft.EntityFrameworkCore;
using MVC_TrendGiysi_Tekrar_.Models.Contexts;
using MVC_TrendGiysi_Tekrar_.Models.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AddConnection
string connectionString = builder.Configuration.GetConnectionString("AtakanConnection");
//AddDbcontext
builder.Services.AddDbContext<GiysiContext>(options => options.UseSqlServer(connectionString));

////RazorRuntime
//builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//UserManager Service => Kullanýcý iþlemlerini yapýlandýrmak için kullanýrýz. (Create, Update, List)
builder.Services.AddIdentity<AppUser, AppUserRole>()
    .AddEntityFrameworkStores<GiysiContext>();


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
