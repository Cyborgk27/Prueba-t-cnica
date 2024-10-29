namespace Consultorio_de_seguros.Models
{
    public class AsignacionSeguroAsegurado
    {
        public int AsignacionId { get; set; }

        public int AseguradoId { get; set; }
        public int SeguroId { get; set; }


        public Asegurado? Asegurado { get; set; } = null!;
        public Seguro? Seguro { get; set; } = null!;
    }

}
