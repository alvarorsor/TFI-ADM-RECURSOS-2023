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

        [Required]
        [StringLength(45)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime fechaInicio { get; set; }

        [Required]
        public DateTime fechaEstimadaEntrega { get; set; }


        
        public DateTime? fechaFinalizacion { get; set; }

       
        public bool finalizado { get; set; }

        [ForeignKey("Cliente-proyecto-FK")]
        public int ClienteId { get; set; }  
        [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }


       


    }
}
