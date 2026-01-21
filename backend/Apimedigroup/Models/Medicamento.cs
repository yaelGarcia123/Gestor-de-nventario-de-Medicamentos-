using System.ComponentModel.DataAnnotations;

namespace Apimedigroup.Models
{
    public class Medicamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage="El nombre es obligatorio")]
        public string nombre { get; set; } =string.Empty;

        [Required]
        public string categoria { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser positiva")]
        public int cantidad { get; set; }

        [Required]
        public DateTime fecha_expiracion { get; set; }

    }
}
