using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PRO401.Entities
{
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "Run requerido")]
        public string Run { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int ComunaResidenciaId { get; set; }
        public int? ComunaTrabajoId { get; set; }
        public int EstadoRegistroId { get; set; }
        public int TipoTrabajoId { get; set; }
        public Encuesta? Encuesta { get; set; }
        public Comuna ComunaResidencia { get; set; }
        public Comuna? ComunaTrabajo { get; set; }
        public EstadoRegistro EstadoRegistro { get; set; }
        public TipoTrabajo TipoTrabajo { get; set; }

    }
}
