using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TFI_ADM_RECURSOS_2023.Models
{
    public class cuentaCorriente
    {

        public int Id { get; set; }


        
        public double? debe { get; set; }

        
        public double? haber { get; set; }

        public double? saldo { get; set; }

        [Required]
        [Display(Name = "Tipo documento")]
        public string tipoDeDocumento { get; set; }

        [Required]
        [Display(Name = "Fecha de pago")]
        public DateTime fechaPago { get; set; }

        [Required]
        [Display(Name = "Código Documento")]
        public int codigoDocumento { get; set; }


        [ForeignKey("ClienteNombre")]
        [Display(Name = "Nombre cliente")]
        public string ClienteNombre { get; set; }
        [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }

        [NotMapped] // No mapear esta propiedad a la base de datos
        public string NombreCompletoCliente => $"{Cliente?.nombre} {Cliente?.apellido}";

    }
}
