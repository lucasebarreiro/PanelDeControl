using PanelDeControl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanelDeControl.Services;

public interface ILinkService
{
    Task<IEnumerable<Link>> GetAllAsync();
    Task<IEnumerable<Link>> SearchAsync(string? q, string? category, string? tag);
    Task AddAsync(Link l);
    Task UpdateAsync(Link l);
    Task DeleteAsync(int id);
}

public class LinkService : ILinkService
{
    private readonly PanelDeControl.Interfaces.ILinkRepository _repo;
    public LinkService(PanelDeControl.Interfaces.ILinkRepository repo) => _repo = repo;

    public Task AddAsync(Link l) => _repo.AddAsync(l);
    public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    public Task<IEnumerable<Link>> GetAllAsync() => _repo.GetAllAsync();
    public Task<IEnumerable<Link>> SearchAsync(string? q, string? category, string? tag) => _repo.SearchAsync(q, category, tag);
    public Task UpdateAsync(Link l) => _repo.UpdateAsync(l);
}
