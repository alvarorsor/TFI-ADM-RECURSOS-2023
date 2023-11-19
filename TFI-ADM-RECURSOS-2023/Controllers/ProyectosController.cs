using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFI_ADM_RECURSOS_2023.Data;
using TFI_ADM_RECURSOS_2023.Models;

namespace TFI_ADM_RECURSOS_2023.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProyectosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proyectos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Proyectos.Include(p => p.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Proyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // GET: Proyectos/Create
        public IActionResult Create()
        {
            ViewData["ClienteNombre"] = new SelectList(_context.Clientes.Select(c => new { c.nombre, c.apellido, NombreCompleto = $"{c.nombre} {c.apellido}" }), "nombre", "NombreCompleto");

            // ViewData["ClienteNombre"] = new SelectList(_context.Clientes, "nombre", "nombre");
            return View();
        }

        // POST: Proyectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre,descripcion,fechaInicio,fechaEstimadaEntrega, ClienteNombre")] Proyecto proyecto)
        {
            /* if (ModelState.IsValid)
             {
                 var cliente = await _context.Clientes.SingleOrDefaultAsync(c => c.nombre == proyecto.ClienteNombre);

                 _context.Add(proyecto);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             ViewData["ClienteNombre"] = new SelectList(_context.Clientes, "nombre", "nombre", proyecto.ClienteNombre);

             return View(proyecto);*/

            if (ModelState.IsValid)
            {
                // Verificar si el Cliente con el nombre especificado existe
                var cliente = await _context.Clientes.SingleOrDefaultAsync(c => c.nombre == proyecto.ClienteNombre);

                if (cliente == null)
                {
                    // El cliente no existe, puedes manejar esto según tus necesidades
                    ModelState.AddModelError("ClienteNombre", "El cliente no existe.");
                    ViewData["ClienteNombre"] = new SelectList(_context.Clientes, "nombre", "nombre", proyecto.ClienteNombre);
                    return View(proyecto);
                }

                // Asignar el Cliente al Proyecto
                proyecto.Cliente = cliente;

                _context.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Crear un SelectList usando la nueva propiedad NombreCompletoCliente
            ViewData["ClienteNombre"] = new SelectList(_context.Clientes.Select(c => new { c.nombre, c.apellido, NombreCompleto = $"{c.nombre} {c.apellido}" }), "NombreCompleto", "NombreCompleto", proyecto.ClienteNombre);
            return View(proyecto);

            /* ViewData["ClienteNombre"] = new SelectList(_context.Clientes, "nombre", "nombre", proyecto.ClienteNombre);
             return View(proyecto);*/
        }

        // GET: Proyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            ViewData["ClienteNombre"] = new SelectList(_context.Clientes, "Id", "nombre", proyecto.ClienteNombre);
            return View(proyecto);
        }

        // POST: Proyectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre,descripcion,fechaInicio,fechaEstimadaEntrega ,ClienteId, finalizado, ClienteNombre, fechaFinalizacion")] Proyecto proyecto)
        {
            if (id != proyecto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (proyecto.finalizado == true)
                    {
                        proyecto.fechaFinalizacion = DateTime.Now;
                    }

                    _context.Update(proyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyectoExists(proyecto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteNombre"] = new SelectList(_context.Clientes, "nombre", "nombre", proyecto.ClienteNombre);
            return View(proyecto);
        }

        // GET: Proyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proyectos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Proyectos'  is null.");
            }
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectoExists(int id)
        {
          return (_context.Proyectos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
