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
    public class proyectosReporteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public proyectosReporteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: proyectosReporte
        public async Task<IActionResult> Index()
        {
              return _context.Proyectos != null ? 
                          View(await _context.Proyectos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Proyectos'  is null.");
        }




        [HttpPost]
        public async Task<IActionResult> BuscarCliente(string nombreCliente, string apellidoCliente)
        {


            // Realizar la consulta LINQ para buscar el proyecto del cliente
            var proyectos = _context.Proyectos
            .Include(c => c.Cliente)
            .Where(c => c.Cliente.nombre == nombreCliente && c.Cliente.apellido == apellidoCliente)
            .ToList();

            // Realizar la consulta LINQ para buscar el cliente
            Cliente cliente = _context.cuentaCorrientes
                .Include(c => c.Cliente)
                .FirstOrDefault(c => c.Cliente.nombre == nombreCliente && c.Cliente.apellido == apellidoCliente)?.Cliente;





            if (proyectos.Count != 0)
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
                                .Text("REPORTE PROYECTOS").FontColor("#fff");

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
                            .Padding(-1).Text("Nombre").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Descripcion").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Fecha Inicio").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Fecha Entrega").FontColor("#fff");

                                    header.Cell().Background("#257272")
                       .Padding(-1).Text("Fecha Finalizacion").FontColor("#fff");

                                    header.Cell().Background("#257272")
                            .Padding(-1).Text("Estado").FontColor("#fff");


                                });

                                foreach (var item in proyectos)
                                {




                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                             .Padding(-1).Text(item.nombre.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                               .Padding(-1).Text(item.descripcion.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                               .Padding(-1).Text(item.fechaInicio.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                           .Padding(-1).Text(item.fechaEstimadaEntrega.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                          .Padding(-1).Text(item.fechaFinalizacion.ToString()).FontSize(10);

                                    if (item.finalizado == true)
                                    {
                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                               .Padding(-1).Text("finalizado").FontSize(10);
                                    }
                                    else {
                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                  .Padding(-1).Text("en proceso").FontSize(10);

                                    }





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
                // Manejar el caso en el que la cuenta corriente no se encuentra
                // ...

                // Devolver una respuesta al cliente (puedes devolver un mensaje de error, por ejemplo)
                return Json(new { mensaje = "Cliente no encontrado" });
                //return Json(new { mensaje = "Cliente no encontrado" });
            }
        }


















        // GET: proyectosReporte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // GET: proyectosReporte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: proyectosReporte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre,descripcion,fechaInicio,fechaEstimadaEntrega,fechaFinalizacion,finalizado,ClienteNombre")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proyecto);
        }

        // GET: proyectosReporte/Edit/5
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
            return View(proyecto);
        }

        // POST: proyectosReporte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre,descripcion,fechaInicio,fechaEstimadaEntrega,fechaFinalizacion,finalizado,ClienteNombre")] Proyecto proyecto)
        {
            if (id != proyecto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            return View(proyecto);
        }

        // GET: proyectosReporte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: proyectosReporte/Delete/5
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
