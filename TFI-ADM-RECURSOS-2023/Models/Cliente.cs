using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public long telefono { get; set; } 

        [Required]
        [StringLength(13)]
        public string CUIT { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_alta { get; set; }

        public virtual List<Proyecto>? Proyectos { get; set; }



       
    }

   
}
