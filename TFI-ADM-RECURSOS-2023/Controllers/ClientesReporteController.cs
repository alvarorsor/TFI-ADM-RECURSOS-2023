using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFI_ADM_RECURSOS_2023.Data;
using TFI_ADM_RECURSOS_2023.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace TFI_ADM_RECURSOS_2023.Controllers
{
    public class ClientesReporteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesReporteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientesReporte
        public async Task<IActionResult> Index()
        {
              return _context.Clientes != null ? 
                          View(await _context.Clientes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Clientes'  is null.");
        }







        [HttpPost]
        public async Task<IActionResult> BuscarCliente(string fechaInicio, string fechaFin)
        {
            // Convertir las fechas de cadena a DateTime
            DateTime.TryParse(fechaInicio, out DateTime fechaInicioDateTime);
            DateTime.TryParse(fechaFin, out DateTime fechaFinDateTime);

            // Realizar la consulta LINQ para buscar la cuenta corriente del cliente
            var clientes = _context.Clientes
            
            .Where(c => c.fecha_alta >= fechaInicioDateTime && c.fecha_alta <= fechaFinDateTime)
            .ToList();

           





            if (clientes.Count != 0)
            {

                var data = Document.Create(document =>
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
                                .Text("REPORTE DE CLIENTES").FontColor("#fff");

                                col.Item().Border(1).BorderColor("#257272").
                                AlignCenter().Text("R0001");


                            });
                        });

                        page.Content().PaddingVertical(10).Column(col1 =>
                        {
                            

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
                            .Padding(-1).Text("Nombre").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Apellido").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Direccion").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Email").FontColor("#fff");

                                    header.Cell().Background("#257272")
                       .Padding(-1).Text("Telefono").FontColor("#fff");

                                    header.Cell().Background("#257272")
                      .Padding(-1).Text("CUIT").FontColor("#fff");




                                });

                                foreach (var item in clientes)
                                {




                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                             .Padding(-1).Text(item.nombre.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                               .Padding(-1).Text(item.apellido.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                               .Padding(-1).Text(item.direccion.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                           .Padding(-1).Text(item.email.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                          .Padding(-1).Text(item.telefono.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                         .Padding(-1).Text(item.CUIT.ToString()).FontSize(10);







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












        // GET: ClientesReporte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: ClientesReporte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientesReporte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre,apellido,direccion,email,telefono,CUIT,fecha_alta")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: ClientesReporte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: ClientesReporte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre,apellido,direccion,email,telefono,CUIT,fecha_alta")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: ClientesReporte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: ClientesReporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
