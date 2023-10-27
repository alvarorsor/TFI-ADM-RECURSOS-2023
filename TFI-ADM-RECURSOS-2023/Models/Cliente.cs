using System.ComponentModel.DataAnnotations;

namespace TFI_ADM_RECURSOS_2023.Models
{
    public class Cliente
    {

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string apellido { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string direccion { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string email { get; set; } = string.Empty;

        [Required]
        [MaxLength(11)]
        public int telefono { get; set; } 

        [Required]
        [StringLength(13)]
        public string CUIT { get; set; } = string.Empty;

        public DateTime fecha_alta { get; set; }

        public virtual List<Proyecto>? Proyectos { get; set; }


    }
}
