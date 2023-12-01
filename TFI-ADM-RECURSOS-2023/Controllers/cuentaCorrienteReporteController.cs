using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFI_ADM_RECURSOS_2023.Data;
using TFI_ADM_RECURSOS_2023.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace TFI_ADM_RECURSOS_2023.Controllers
{
    public class cuentaCorrienteReporteController : Controller
    {

     


        private readonly ApplicationDbContext _context;

        public cuentaCorrienteReporteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: cuentaCorrienteReporte
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.cuentaCorrientes;
            return View(await applicationDbContext.ToListAsync());
        }


     
            [HttpPost]
            public async Task<IActionResult> BuscarCliente(string nombreCliente)
            {


            // Realizar la consulta LINQ para buscar la cuenta corriente del cliente
            var cuentasCorrientes = _context.cuentaCorrientes
            .Include(c => c.Cliente)
            .Where(c => c.Cliente.nombre == nombreCliente)
            .ToList();

            // Realizar la consulta LINQ para buscar el cliente
            Cliente cliente = _context.cuentaCorrientes
                .Include(c => c.Cliente)
                .FirstOrDefault(c => c.Cliente.nombre == nombreCliente)?.Cliente;





            if (cuentasCorrientes.Count != 0)
            {

              var data =  Document.Create(document =>
                {
                    document.Page(page =>
                    {

                        page.Margin(30);
                        //page.Header().Height(100).Background(Colors.Blue.Medium);
                        //page.Content().Background(Colors.Yellow.Medium);
                        //page.Footer().Height(50).Background(Colors.Red.Medium);

                        page.Header().ShowOnce().Row(row =>
                        {
                           // row.ConstantItem(140).Height(60).Placeholder();


                            row.RelativeItem().Column(col =>
                            {
                                col.Item().AlignCenter().Text("INTRASOFT").Bold().FontSize(14);
                                col.Item().AlignCenter().Text("Las mercedes N378 - SM TUCUMAN").FontSize(9);
                                col.Item().AlignCenter().Text("987 987 123 / 02 213232").FontSize(9);
                                col.Item().AlignCenter().Text("intrasoft@gmail.com").FontSize(9);

                            });

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Border(1).BorderColor("#257272")
                                .AlignCenter().Text("RUC 21312312312");

                                col.Item().Background("#257272").Border(1)
                                .BorderColor("#257272").AlignCenter()
                                .Text("REPORTE CUENTA CORRIENTE").FontColor("#fff");

                                col.Item().Border(1).BorderColor("#257272").
                                AlignCenter().Text("R0001");


                            });
                        });

                        page.Content().PaddingVertical(10).Column(col1 =>
                        {
                            col1.Item().Column(col2 =>
                            {
                                col2.Item().Text("Datos del cliente").Underline().Bold();

                                col2.Item().Text(txt =>
                                {
                                    txt.Span("Nombre: ").SemiBold().FontSize(10);
                                txt.Span(cliente.nombre + " " + cliente.apellido).FontSize(10);
                                });

                                col2.Item().Text(txt =>
                                {
                                    txt.Span("CUIT: ").SemiBold().FontSize(10);
                                    txt.Span(cliente.CUIT.ToString()).FontSize(10);
                                });

                                col2.Item().Text(txt =>
                                {
                                    txt.Span("Direccion: ").SemiBold().FontSize(10);
                                    txt.Span(cliente.direccion).FontSize(10);
                                });
                            });

                            col1.Item().LineHorizontal(0.5f);

                            col1.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(85);
                                    columns.ConstantColumn(85);
                                    columns.ConstantColumn(85);
                                    columns.ConstantColumn(85);
                                    columns.ConstantColumn(85);
                                    columns.ConstantColumn(85);

                                });


                                tabla.Header(header =>
                                {
                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Debe").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Haber").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Saldo").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Documento").FontColor("#fff");

                                    header.Cell().Background("#257272")
                       .Padding(-1).Text("Fecha pago").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Codigo documento").FontColor("#fff");

                                    
                                });

                                foreach (var item in cuentasCorrientes)
                                {


                                  

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                             .Padding(-1).Text(item.debe.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                               .Padding(-1).Text(item.haber.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                               .Padding(-1).Text(item.saldo.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                           .Padding(-1).Text(item.tipoDeDocumento.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                          .Padding(-1).Text(item.fechaPago.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                           .Padding(-1).Text(item.codigoDocumento.ToString()).FontSize(10);

                                    




                                }

                            });

                          

                            col1.Spacing(10);
                        });


                        page.Footer()
                        .AlignRight()
                        .Text(txt =>
                        {
                            txt.Span("Pagina ").FontSize(10);
                            txt.CurrentPageNumber().FontSize(10);
                            txt.Span(" de ").FontSize(10);
                            txt.TotalPages().FontSize(10);
                        });
                    });
                }).GeneratePdf();

                Stream stream = new MemoryStream(data);
                return File(stream, "application/pdf", "reporteCliente.pdf");

                //return PartialView("_TablaCuentaCorriente", cuentasCorrientes);

            }
            else
            {
               

                // Devolver un resultado JSON con el mensaje de error
                return Json(new { error = "Cliente no encontrado" });
            }
        }
    
        


        // GET: cuentaCorrienteReporte/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: cuentaCorrienteReporte/Create
        public IActionResult Create()
        {
           //ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "condicionTributaria");
            return View();
        }

        // POST: cuentaCorrienteReporte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,debe,haber,saldo,tipoDeDocumento,fechaPago,FacturaId,ClienteNombre, codigoDocumento")] cuentaCorriente cuentaCorriente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuentaCorriente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "condicionTributaria", cuentaCorriente.FacturaId);
            return View(cuentaCorriente);
        }

        // GET: cuentaCorrienteReporte/Edit/5
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
           // ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "condicionTributaria", cuentaCorriente.FacturaId);
            return View(cuentaCorriente);
        }

        // POST: cuentaCorrienteReporte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,debe,haber,saldo,tipoDeDocumento,fechaPago,FacturaId,ClienteNombre,codigoDocumento")] cuentaCorriente cuentaCorriente)
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
           // ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "condicionTributaria", cuentaCorriente.FacturaId);
            return View(cuentaCorriente);
        }

        // GET: cuentaCorrienteReporte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cuentaCorrientes == null)
            {
                return NotFound();
            }

            var cuentaCorriente = await _context.cuentaCorrientes
              //  .Include(c => c.Factura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuentaCorriente == null)
            {
                return NotFound();
            }

            return View(cuentaCorriente);
        }

        // POST: cuentaCorrienteReporte/Delete/5
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
