using System.ComponentModel.DataAnnotations;

namespace TFI_ADM_RECURSOS_2023.Models
{
    public class Recurso
    {

        public int Id { get; set; }

        [Required]
        public string nombre { get; set; } = string.Empty;

        [Required]
        public string apellido { get; set; } = string.Empty;

        [Required]
        public string rol { get; set; } = string.Empty;



    }
}
