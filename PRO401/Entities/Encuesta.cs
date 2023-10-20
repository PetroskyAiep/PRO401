using System.ComponentModel.DataAnnotations.Schema;


namespace PRO401.Entities
{
    public class Encuesta
    {
        public int Id { get; set; }
        public int EstadoEncuesta { get; set; }
        public int TiempoAproximado { get; set; }
        public int KmAproximado { get; set; }
        public int TipoTransporteId { get; set; }
        public TipoTransporte TipoTransporte { get; set; }
        [ForeignKey("Usuario")]
        public string UsuarioEmail { get; set; }
        public Usuario Usuario { get; set; }

    }
}
