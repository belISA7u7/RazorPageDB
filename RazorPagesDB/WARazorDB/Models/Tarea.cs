using System.ComponentModel.DataAnnotations;

namespace WARazorDB.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la tarea es obligatorio.")]
        [StringLength(80, ErrorMessage = "El nombre no puede tener más de 80 caracteres.")]
        public string nombreTarea { get; set; } = "";

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        [DataType(DataType.DateTime)]
        public DateTime fechaVencimiento { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [RegularExpression("Pendiente|En Curso|Finalizado|Cancelado", ErrorMessage = "Estado inválido.")]
        public string estado { get; set; } = "";

        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [Range(1, 10, ErrorMessage = "El usuario debe estar entre 1 y 10.")]
        public int idUsuario { get; set; }
    }
}
