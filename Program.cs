using Microsoft.EntityFrameworkCore;
using PanelDeControl.Data;
using PanelDeControl.Interfaces;
using PanelDeControl.Repositories;
using PanelDeControl.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Supabase: prefer an explicit SUPABASE_CONNECTION env var. Otherwise use appsettings DefaultConnection.
// If the DefaultConnection contains a placeholder password (YOUR_SUPABASE_DB_PASSWORD), the code will try
// to replace it with the SUPABASE_DB_PASSWORD env var.

var configuredConnection = builder.Configuration.GetConnectionString("DefaultConnection")
                         ?? Environment.GetEnvironmentVariable("SUPABASE_CONNECTION");

var supabasePasswordEnv = Environment.GetEnvironmentVariable("SUPABASE_DB_PASSWORD");

if (!string.IsNullOrWhiteSpace(configuredConnection) && configuredConnection.Contains("YOUR_SUPABASE_DB_PASSWORD"))
{
    if (!string.IsNullOrWhiteSpace(supabasePasswordEnv))
    {
        configuredConnection = configuredConnection.Replace("YOUR_SUPABASE_DB_PASSWORD", supabasePasswordEnv);
    }
}

var useSupabase = false;
if (!string.IsNullOrWhiteSpace(configuredConnection) && configuredConnection.Contains("supabase.co", StringComparison.OrdinalIgnoreCase))
{
    useSupabase = true;
}

if (useSupabase)
{
    Console.WriteLine("[Info] Using Supabase/Postgres connection.");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(configuredConnection));
}
else
{
    Console.WriteLine("[Info] No Supabase configuration detected — using local SQLite (links.db) as fallback.");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=links.db"));
}

builder.Services.AddScoped<ILinkRepository, EfLinkRepository>();
builder.Services.AddScoped<ILinkService, LinkService>();

var app = builder.Build();

// Ensure DB is created in development when using SQLite fallback to avoid missing table errors
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        // If using SQLite fallback, call EnsureCreated to create tables without migrations (dev convenience).
        if (!useSupabase)
        {
            db.Database.EnsureCreated();
            Console.WriteLine("[Info] SQLite DB ensured/created.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[Error] Failed to ensure/create database: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();
