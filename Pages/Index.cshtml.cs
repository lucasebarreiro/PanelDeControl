using Microsoft.AspNetCore.Mvc.RazorPages;
using PanelDeControl.Models;
using PanelDeControl.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PanelDeControl.Pages;

public class IndexModel : PageModel
{
    private readonly ILinkService _service;
    public IndexModel(ILinkService service) => _service = service;

    public IEnumerable<Link> Links { get; set; } = new List<Link>();

    [BindProperty(SupportsGet = true)]
    public string? Q { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Category { get; set; }

    public async Task OnGetAsync()
    {
        Links = await _service.SearchAsync(Q, Category, null);
    }
}
