using PanelDeControl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanelDeControl.Interfaces;

public interface ILinkRepository
{
    Task<IEnumerable<Link>> GetAllAsync();
    Task<Link?> GetByIdAsync(int id);
    Task<IEnumerable<Link>> SearchAsync(string? q, string? category, string? tag);
    Task AddAsync(Link link);
    Task UpdateAsync(Link link);
    Task DeleteAsync(int id);
}
