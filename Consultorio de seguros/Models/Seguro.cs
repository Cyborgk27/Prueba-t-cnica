using System.ComponentModel.DataAnnotations;

namespace Consultorio_de_seguros.Models
{
    public class Seguro
    {
        public Seguro()
        {
            Asignaciones = [];
        }
        public int SeguroId { get; set; }
        [Required(ErrorMessage = "El nombre del seguro es requerido.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El código de seguro es requerido.")]
        [RegularExpression(@"^[A-Z0-9]{5,10}$", ErrorMessage = "El código de seguro debe tener entre 5 y 10 caracteres alfanuméricos.")]
        public string? CodigoSeguro { get; set; }

        [Required(ErrorMessage = "La suma asegurada es requerida.")]
        [Range(1, double.MaxValue, ErrorMessage = "La suma asegurada debe ser un valor positivo.")]
        public decimal? SumaAsegurada { get; set; }

        [Required(ErrorMessage = "La prima es requerida.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La prima debe ser un valor positivo.")]
        public decimal Prima { get; set; }



        public ICollection<AsignacionSeguroAsegurado> Asignaciones { get; set; } = null!;
    }

}
