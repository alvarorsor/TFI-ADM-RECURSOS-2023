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
    public class cuentasCorrienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public cuentasCorrienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: cuentasCorriente
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.cuentaCorrientes;
            return View(await applicationDbContext.ToListAsync());
        }




        // GET: cuentasCorriente/Search
        public async Task<IActionResult> Search(string clientName)
        {
            var query = _context.cuentaCorrientes.Where(c => c.ClienteNombre.Contains(clientName));
            return View("Index", await query.ToListAsync());
        }

        // GET: cuentasCorriente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cuentaCorrientes == null)
            {
                return NotFound();
            }

            var cuentaCorriente = await _context.cuentaCorrientes
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuentaCorriente == null)
            {
                return NotFound();
            }

            return View(cuentaCorriente);
        }

        // GET: cuentasCorriente/Create
        public IActionResult Create()
        {
            ViewData["ClienteNombre"] = new SelectList(_context.Clientes.Select(c => new { c.nombre, c.apellido, NombreCompleto = $"{c.nombre} {c.apellido}" }), "nombre", "NombreCompleto");

            
            return View();
        }

        // POST: cuentasCorriente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,debe,haber,saldo,tipoDeDocumento,fechaPago,FacturaId,ClienteNombre, codigoDocumento")] cuentaCorriente cuentaCorriente)
        {
            /* if (ModelState.IsValid)
             {
                 _context.Add(cuentaCorriente);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "condicionTributaria", cuentaCorriente.FacturaId);
             return View(cuentaCorriente);*/


            if (ModelState.IsValid)
            {
                cuentaCorriente.saldo = cuentaCorriente.haber - cuentaCorriente.debe;
                // Verificar si el Cliente con el nombre especificado existe
                var cliente = await _context.Clientes.SingleOrDefaultAsync(c => c.nombre == cuentaCorriente.ClienteNombre);

                if (cliente == null)
                {
                    // El cliente no existe, puedes manejar esto según tus necesidades
                    ModelState.AddModelError("ClienteNombre", "El cliente no existe.");
                    ViewData["ClienteNombre"] = new SelectList(_context.Clientes, "nombre", "nombre", cuentaCorriente.ClienteNombre);
                    return View(cuentaCorriente);
                }

                // Asignar el Cliente al Proyecto
                cuentaCorriente.Cliente = cliente;

                _context.Add(cuentaCorriente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Crear un SelectList usando la nueva propiedad NombreCompletoCliente
            ViewData["ClienteNombre"] = new SelectList(_context.Clientes.Select(c => new { c.nombre, c.apellido, NombreCompleto = $"{c.nombre} {c.apellido}" }), "NombreCompleto", "NombreCompleto", cuentaCorriente.ClienteNombre);

            //ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", cuentaCorriente.FacturaId);

            return View(cuentaCorriente);
        }

        // GET: cuentasCorriente/Edit/5
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
            //ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", cuentaCorriente.FacturaId);
            return View(cuentaCorriente);
        }

        // POST: cuentasCorriente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,debe,haber,saldo,tipoDeDocumento,fechaPago,FacturaId,ClienteNombre, codigoDocumento")] cuentaCorriente cuentaCorriente)
        {
            if (id != cuentaCorriente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
           // ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", cuentaCorriente.FacturaId);
            return View(cuentaCorriente);
        }

        // GET: cuentasCorriente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cuentaCorrientes == null)
            {
                return NotFound();
            }

            var cuentaCorriente = await _context.cuentaCorrientes
               // .Include(c => c.Factura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuentaCorriente == null)
            {
                return NotFound();
            }

            return View(cuentaCorriente);
        }

        // POST: cuentasCorriente/Delete/5
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
