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

        [ForeignKey("Cliente-cuentaCorriente-FK")]
        public int ClienteId { get; set; }
        [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }
    }
}
