using PRO401.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRO401.DTO.EncuestaDTO
{
    public class EncuestaCreateDTO
    {
        public int EstadoEncuesta { get; set; }
        public int TiempoAproximado { get; set; }
        public int KmAproximado { get; set; }
        public int TipoTransporteId { get; set; }
        public string UsuarioEmail { get; set; }
    }
}
