using Microsoft.EntityFrameworkCore;
using AdminPdfReaderApp.Data; // Include your Data namespace for ApplicationDbContext

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add database context for ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdminDbConnection")));

// Add controllers with views
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

// Enable serving of static files (like PDFs, images, etc.)
app.UseStaticFiles();  // This is required for accessing files in the wwwroot folder

// Set up routing
app.UseRouting();

// Authorization middleware
app.UseAuthorization();

// Define the default route pattern
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Login}/{id?}");

// Run the app
app.Run();
