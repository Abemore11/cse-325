using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

/*
1. Create app builder
2. Register services
3. Build app
4. Configure middleware pipeline
5. Configure routing/pages/assets
6. Start server
*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Selects the SQLite connection string in development and SQL Server in production.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext")));
}
else
{
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMovieContext")));
}

// Register a database connection using SQLite
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

var app = builder.Build();

// Adds seed initializer.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirect all HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Adds route matching to the middleware pipeline. This middleware looks at the incoming request and matches it to the defined routes in the application.
app.UseRouting();

//Optimizes the delivery of static assets in an app, such as HTML, CSS, images, and JavaScript.
app.MapStaticAssets();
app.MapRazorPages() // Configs enpoint routing for Razor Pages.
   .WithStaticAssets(); //Ensures Razor Pages participate in the optimization system for static assets.

app.Run();
