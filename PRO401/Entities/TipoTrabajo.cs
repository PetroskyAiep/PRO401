namespace PRO401.Entities
{
    public class TipoTrabajo
    {
        public int Id { get; set; }
        public string Modalidad { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
