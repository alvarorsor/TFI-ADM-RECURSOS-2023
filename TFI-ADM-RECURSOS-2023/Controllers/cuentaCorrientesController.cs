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
    public class cuentaCorrientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public cuentaCorrientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: cuentaCorrientes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.cuentaCorrientes.Include(c => c.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: cuentaCorrientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cuentaCorrientes == null)
            {
                return NotFound();
            }

            var cuentaCorriente = await _context.cuentaCorrientes
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuentaCorriente == null)
            {
                return NotFound();
            }

            return View(cuentaCorriente);
        }

        // GET: cuentaCorrientes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "CUIT");
            return View();
        }

        // POST: cuentaCorrientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,debe,haber,saldo,ClienteId")] cuentaCorriente cuentaCorriente)
        {
            if (ModelState.IsValid)
            {
                cuentaCorriente.saldo = cuentaCorriente.debe - cuentaCorriente.haber;

                _context.Add(cuentaCorriente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "CUIT", cuentaCorriente.ClienteId);
            return View(cuentaCorriente);
        }

        // GET: cuentaCorrientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cuentaCorrientes == null)
            {
                return NotFound();
            }

            var cuentaCorriente = await _context.cuentaCorrientes.FindAsync(id);
            if (cuentaCorriente == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "CUIT", cuentaCorriente.ClienteId);
            return View(cuentaCorriente);
        }

        // POST: cuentaCorrientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,debe,haber,saldo,ClienteId")] cuentaCorriente cuentaCorriente)
        {
            if (id != cuentaCorriente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cuentaCorriente.saldo = cuentaCorriente.debe - cuentaCorriente.haber;

                    _context.Update(cuentaCorriente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cuentaCorrienteExists(cuentaCorriente.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "CUIT", cuentaCorriente.ClienteId);
            return View(cuentaCorriente);
        }

        // GET: cuentaCorrientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cuentaCorrientes == null)
            {
                return NotFound();
            }

            var cuentaCorriente = await _context.cuentaCorrientes
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuentaCorriente == null)
            {
                return NotFound();
            }

            return View(cuentaCorriente);
        }

        // POST: cuentaCorrientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cuentaCorrientes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.cuentaCorrientes'  is null.");
            }
            var cuentaCorriente = await _context.cuentaCorrientes.FindAsync(id);
            if (cuentaCorriente != null)
            {
                _context.cuentaCorrientes.Remove(cuentaCorriente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cuentaCorrienteExists(int id)
        {
          return (_context.cuentaCorrientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
