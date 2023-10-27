using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TFI_ADM_RECURSOS_2023.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required]
        public string nombre { get; set;} = string.Empty;   

        [Required]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime fechaInicio { get; set; } 

        [Required]
        public string estadoTarea { get; set; } = string.Empty;

        [Required]
        public int horasEstimadas { get; set; }

        [ForeignKey("Recurso-tarea-FK")]
        public int RecursoId { get; set; }
        [JsonIgnore]
        public virtual Recurso? Recurso { get; set; }

        [ForeignKey("Proyecto-tarea-FK")]
        public int? ProyectoId { get; set; }
        [JsonIgnore]
        public virtual Proyecto? Proyecto { get; set; }
    }
}
