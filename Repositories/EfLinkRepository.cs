using Microsoft.EntityFrameworkCore;
using PanelDeControl.Data;
using PanelDeControl.Interfaces;
using PanelDeControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelDeControl.Repositories;

public class EfLinkRepository : ILinkRepository
{
    private readonly AppDbContext _db;
    public EfLinkRepository(AppDbContext db) => _db = db;

    public async Task AddAsync(Link link)
    {
        _db.Links.Add(link);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var e = await _db.Links.FindAsync(id);
        if (e != null)
        {
            _db.Links.Remove(e);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Link>> GetAllAsync()
        => await _db.Links.OrderByDescending(l => l.IsFavorite).ThenByDescending(l => l.CreatedAt).ToListAsync();

    public async Task<Link?> GetByIdAsync(int id) => await _db.Links.FindAsync(id);

    public async Task<IEnumerable<Link>> SearchAsync(string? q, string? category, string? tag)
    {
        var query = _db.Links.AsQueryable();
        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(l => EF.Functions.ILike(l.Title, $"%{q}%") || EF.Functions.ILike(l.Description ?? string.Empty, $"%{q}%") || EF.Functions.ILike(l.Url, $"%{q}%"));
        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(l => l.Category == category);
        if (!string.IsNullOrWhiteSpace(tag))
            query = query.Where(l => EF.Functions.ILike(l.Tags ?? string.Empty, $"%{tag}%"));

        return await query.OrderByDescending(l => l.IsFavorite).ThenByDescending(l => l.CreatedAt).ToListAsync();
    }

    public async Task UpdateAsync(Link link)
    {
        _db.Links.Update(link);
        await _db.SaveChangesAsync();
    }
}
