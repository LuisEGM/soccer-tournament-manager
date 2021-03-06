using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.Partidos
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioNovedadPartido _repoNovedadPartido;

        public IEnumerable<NovedadPartido> novedades {get; set;}
        public Partido partido {get; set;}
        public DetailsModel(IRepositorioPartido repoPartido, IRepositorioNovedadPartido repoNovedadPartido)
        {
            _repoPartido = repoPartido;
            _repoNovedadPartido = repoNovedadPartido;
        }
        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            novedades = _repoNovedadPartido.getAllNovedadesByPartido(id);
            if(partido == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
