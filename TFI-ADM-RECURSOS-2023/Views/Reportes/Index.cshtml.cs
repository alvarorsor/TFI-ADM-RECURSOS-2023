using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TFI_ADM_RECURSOS_2023.Data;
using TFI_ADM_RECURSOS_2023.Models;

namespace TFI_ADM_RECURSOS_2023.Views.Reportes
{
    public class CuentaCorrienteReporteModel : PageModel
    {
        private readonly TFI_ADM_RECURSOS_2023.Data.ApplicationDbContext _context;

        public CuentaCorrienteReporteModel(TFI_ADM_RECURSOS_2023.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<cuentaCorriente> cuentaCorriente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.cuentaCorrientes != null)
            {
                cuentaCorriente = await _context.cuentaCorrientes.ToListAsync();
            }
        }
    }
}
