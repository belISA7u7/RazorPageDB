using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WARazorDB.Models;
using System.Linq;

namespace WARazorDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WARazorDB.Data.TareaDbContext _context;
        public IndexModel(WARazorDB.Data.TareaDbContext context)
        {
            _context = context;
        }

        public List<Tarea> Tarea { get; set; } = new();
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        [BindProperty(SupportsGet = true)]
        public string EstadoFiltro { get; set; } = "Todas";

        public async Task OnGetAsync(int pageNumber = 1, string estadoFiltro = "Todas")
        {
            const int pageSize = 10;
            var query = _context.Tareas.AsQueryable();

            if (!string.IsNullOrEmpty(estadoFiltro) && estadoFiltro != "Todas")
            {
                
                query = query.Where(t => t.estado.ToLower() == estadoFiltro.ToLower());
            }

            var totalItems = await Task.FromResult(query.Count());
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            PageNumber = pageNumber;

            Tarea = await Task.FromResult(
                query
                .OrderByDescending(t => t.fechaVencimiento)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList()
            );
            EstadoFiltro = estadoFiltro;
        }
    }
}