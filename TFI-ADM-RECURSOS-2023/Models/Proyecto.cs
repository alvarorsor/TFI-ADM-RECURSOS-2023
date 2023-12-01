using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TFI_ADM_RECURSOS_2023.Models
{
    public class Proyecto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string nombre { get; set; } = string.Empty;

        [NotMapped] // No mapear esta propiedad a la base de datos
        public string NombreCompletoCliente => $"{Cliente?.nombre} {Cliente?.apellido}";

        [Required]
        [StringLength(45)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Fecha de inicio")]
        public DateTime fechaInicio { get; set; }

        [Required]
        [Display(Name = "Fecha estimada entrega")]
        public DateTime fechaEstimadaEntrega { get; set; }


        [Display(Name = "Fecha de finalizacion")]
        public DateTime? fechaFinalizacion { get; set; }

       
        public bool finalizado { get; set; }

        /*[ForeignKey("Cliente-proyecto-FK")]
        public int ClienteId { get; set; }
       [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }*/

        [Display(Name = "Nombre del cliente")]
        [ForeignKey("ClienteNombre")]
        public string ClienteNombre { get; set; }
        [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }




    }
}
