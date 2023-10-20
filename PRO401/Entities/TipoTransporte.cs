namespace PRO401.Entities
{
    public class TipoTransporte
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public bool Comparte { get; set; }
        public List<Transporte> Transportes { get; set; }
        public List<Encuesta> Encuestas { get; set; }
    }
}
