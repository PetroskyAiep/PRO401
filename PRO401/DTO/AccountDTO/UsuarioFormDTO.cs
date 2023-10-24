namespace PRO401.DTO.AccountDTO
{
    public class UsuarioFormDTO : UserCredentials
    {
        public string Run { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int ComunaResidenciaId { get; set; }
        public int? ComunaTrabajoId { get; set; }
        public int EstadoRegistroId { get; set; }
        public int TipoTrabajoId { get; set; }
    }
}
