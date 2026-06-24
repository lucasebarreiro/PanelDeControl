using Microsoft.EntityFrameworkCore;
using PanelDeControl.Data;
using PanelDeControl.Interfaces;
using PanelDeControl.Repositories;
using PanelDeControl.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// DbContext: use DefaultConnection or SUPABASE_CONNECTION env var
var connection = builder.Configuration.GetConnectionString("DefaultConnection")
                 ?? Environment.GetEnvironmentVariable("SUPABASE_CONNECTION");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connection));

builder.Services.AddScoped<ILinkRepository, EfLinkRepository>();
builder.Services.AddScoped<ILinkService, LinkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();
