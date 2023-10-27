using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TFI_ADM_RECURSOS_2023.Models
{
    public class Factura
    {
        public int Id { get; set; }

        [Required]
        public string condicionTributaria { get; set; } = string.Empty;

        [Required]
        public DateTime fechaEmision { get; set; }

        [Required]
        public DateTime fechaVencimiento { get; set; }

        [Required]
        public double total { get; set; }

       
        [ForeignKey("Cliente-factura-FK")]
        public int ClienteId { get; set; }
        [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }

        [ForeignKey("Proyecto-factura-FK")]
        public int? ProyectoId { get; set; }
        [JsonIgnore]
        public virtual Proyecto? Proyecto { get; set; }

    }
}
