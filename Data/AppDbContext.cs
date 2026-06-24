using Microsoft.EntityFrameworkCore;
using PanelDeControl.Models;

namespace PanelDeControl.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Link> Links { get; set; }
}
