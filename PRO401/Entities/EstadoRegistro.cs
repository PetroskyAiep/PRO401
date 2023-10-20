namespace PRO401.Entities
{
    public class EstadoRegistro
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
