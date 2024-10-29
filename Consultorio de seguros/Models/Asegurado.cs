using System.ComponentModel.DataAnnotations;

namespace Consultorio_de_seguros.Models
{
    public class Asegurado
    {
        public Asegurado() 
        {
            Asignaciones = [];
        }
        public int AseguradoId { get; set; }

        [Required(ErrorMessage = "La cédula es requerida.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "La cédula debe tener 10 dígitos.")]
        public string? Cedula { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos.")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "La edad es requerida.")]
        [Range(1, 120, ErrorMessage = "La edad debe estar entre 1 y 120.")]
        public int Edad { get; set; }

        public ICollection<AsignacionSeguroAsegurado> Asignaciones { get; set; } = null!;
    }

}
