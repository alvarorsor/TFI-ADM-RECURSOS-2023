using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TFI_ADM_RECURSOS_2023.Models
{
    public class cuentaCorriente
    {

        public int Id { get; set; }


        [Required]
        public double? debe { get; set; }

        [Required]
        public double haber { get; set; }

        public double saldo { get; set; }

        [Required]
        public string tipoDeDocumento { get; set; }

        [Required]
        public DateTime fechaPago { get; set; }


        [ForeignKey("cuentaCorriente-factura-FK")]
        public int FacturaId { get; set; }
        [JsonIgnore]
        public virtual Factura? Factura { get; set; }

        [ForeignKey("ClienteNombre")]
        public string ClienteNombre { get; set; }
        [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }

        [NotMapped] // No mapear esta propiedad a la base de datos
        public string NombreCompletoCliente => $"{Cliente?.nombre} {Cliente?.apellido}";

    }
}
