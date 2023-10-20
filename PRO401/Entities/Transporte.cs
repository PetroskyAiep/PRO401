using System.ComponentModel.DataAnnotations;

namespace PRO401.Entities
{
    public class Transporte
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        public string Nombre { get; set; }
        public int TipoTransporteId { get; set; }
        public TipoTransporte TipoTransporte { get; set; }
    }
}
