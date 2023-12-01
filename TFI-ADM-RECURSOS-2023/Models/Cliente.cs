using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFI_ADM_RECURSOS_2023.Models
{
    public class Cliente
    {

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Display(Name = "Apellido")]
        public string apellido { get; set; } = string.Empty;



        [Required]
        [StringLength(30)]
        [Display(Name = "Direccion")]
        public string direccion { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        [Display(Name = "Email")]
        public string email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Telefono")]
        public long telefono { get; set; } 

        [Required]
        public long CUIT { get; set; }

        [Required]
        [Display(Name = "Fecha alta")]
        public DateTime fecha_alta { get; set; }

        public virtual List<Proyecto>? Proyectos { get; set; }



       
    }

   
}
