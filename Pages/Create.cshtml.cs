using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PanelDeControl.Models;
using PanelDeControl.Services;
using System.Threading.Tasks;

namespace PanelDeControl.Pages;

public class CreateModel : PageModel
{
    private readonly ILinkService _service;
    public CreateModel(ILinkService service) => _service = service;

    [BindProperty]
    public Link Link { get; set; } = new Link();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await _service.AddAsync(Link);
        return RedirectToPage("Index");
    }
}
