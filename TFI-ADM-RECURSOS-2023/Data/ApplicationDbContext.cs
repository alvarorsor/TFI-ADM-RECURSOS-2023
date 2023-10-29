using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using TFI_ADM_RECURSOS_2023.Models;

namespace TFI_ADM_RECURSOS_2023.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
          {



                  var cliente1 = new Cliente
                {
                    Id = 1,
                    nombre = "Juan",
                    apellido = "perez",
                    telefono = 1234567,
                    CUIT = "23-39572450-9",
                    direccion = "av alem 330",
                    email = "juanperez@gmail.com",
                    fecha_alta = DateTime.Now
                };

              var cliente2 = new Cliente
              {
                  Id = 2,
                  nombre = "Juan",
                  apellido = "perez",
                  telefono = 1234567,
                  CUIT = "23-39572450-9",
                  direccion = "av alem 330",
                  email = "juanperez@gmail.com",
                  fecha_alta = DateTime.Now
              };




              var proyecto1 = new Proyecto
                  {
                      Id = 1,
                      ClienteId = 2,
                      descripcion = "desarrollo de una aplicacion web",
                      nombre = "proyecto A",
                      fechaInicio = DateTime.Now.Date,

                      fechaFinalizacion = DateTime.Now.AddMonths(5).Date,
                      fechaEstimadaEntrega = DateTime.Now.AddMonths(4).Date,

                  };

              var tarea1 = new Tarea
              {
                  Id = 1,
                  nombre = "Tarea1",
                  descripcion = "descripcion de la tarea1",
                  estadoTarea = "pendiente",
                  fechaInicio = DateTime.Now.Date,
                  horasEstimadas = 1200,
                  ProyectoId = 1,
                  RecursoId = 1

              };

              var recurso1 = new Recurso
              {
                  Id = 1,
                   apellido= "Roman",
                   nombre="Juan",
                    rol="Analista funcional"

              };

              var factura1 = new Factura
              {
                  Id = 1,
                   fechaEmision = DateTime.Now,
                    total = 5000, 
                     condicionTributaria = "Responsable inscripto",
                      fechaVencimiento = DateTime.Now.AddMonths(5),
                       ClienteId = 1, 
                       ProyectoId = 1



              };



              var cuentaCorriente1 = new cuentaCorriente
              {
                  Id = 1,
                   debe = 0,
                    haber = 1000, 
                     saldo = 1000, 
                     ClienteId = 1


              };



              modelBuilder.Entity<Cliente>().HasData(cliente1, cliente2);

              modelBuilder.Entity<Proyecto>().HasData(proyecto1);

              modelBuilder.Entity<Tarea>().HasData(tarea1);

              modelBuilder.Entity<Recurso>().HasData(recurso1);

              modelBuilder.Entity<Factura>().HasData(factura1);



              modelBuilder.Entity<cuentaCorriente>().HasData(cuentaCorriente1);



              base.OnModelCreating(modelBuilder);


          }  */

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Proyecto> Proyectos { get; set; }

        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<Recurso> Recursos { get; set; }

        public DbSet<Factura> Facturas { get; set; }

      

        public DbSet<cuentaCorriente> cuentaCorrientes { get; set; }
    }
}