using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TFI_ADM_RECURSOS_2023.Models
{
    public class Linea_de_factura
    {
        public int Id { get; set; }

        [Required]
        public double precio { get; set; }

        [Required]
        public string item { get; set; } = string.Empty;

        [ForeignKey("Factura-lineafactura-FK")]
        public int FacturaId { get; set; }
        [JsonIgnore]
        public virtual Factura Factura { get; set; }
    }
}
