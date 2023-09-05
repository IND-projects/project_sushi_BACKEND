using Microsoft.EntityFrameworkCore;
using ProjectSushi.Database.ProjectSushiDbContext;
using ProjectSushi.Database.Services;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectSushiContext>(db =>
    db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b=> b.MigrationsAssembly("ProjectSushi.Web")));
builder.Services.AddTransient<IUseDatabaseService, UseDatabaseService>();
builder.Services.AddCors(options =>
    options.AddPolicy("MyCorsPolicy", builder => 
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

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

app.UseCors("MyCorsPolicy");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
