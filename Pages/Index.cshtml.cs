using Microsoft.AspNetCore.Mvc.RazorPages;
using PanelDeControl.Models;

namespace PanelDeControl.Pages;

public class IndexModel : PageModel
{
    public List<Link> Links { get; set; } = new();

    public void OnGet()
    {
        // Enlaces de ejemplo para la vista solo-front. Cámbialos por los que uses en tu trabajo.
        Links = new List<Link>
        {
            new Link { Id = 1, Title = "GitHub", Url = "https://github.com", Description = "Repositorio y gestión de código", Category = "Dev", Tags = "git,repos", IsFavorite = true },
            new Link { Id = 2, Title = "Jira", Url = "https://your-jira.example.com", Description = "Gestión de incidencias y tareas", Category = "Gestión", Tags = "issues,board", IsFavorite = false },
            new Link { Id = 3, Title = "Confluence", Url = "https://your-confluence.example.com", Description = "Documentación interna", Category = "Docs", Tags = "wiki,docs", IsFavorite = false },
            new Link { Id = 4, Title = "CI/CD Dashboard", Url = "https://ci.example.com", Description = "Pipelines y despliegues", Category = "Ops", Tags = "ci,deploy", IsFavorite = true },
            new Link { Id = 5, Title = "Supabase Console", Url = "https://zwirxnsdhgsmypwqxiah.supabase.co", Description = "Panel de Supabase (DB/Auth/Storage)", Category = "Infra", Tags = "db,auth", IsFavorite = false },
            new Link { Id = 6, Title = "Monitoring", Url = "https://monitoring.example.com", Description = "Alertas y métricas", Category = "Ops", Tags = "metrics,logs", IsFavorite = false }
        };
    }
}
