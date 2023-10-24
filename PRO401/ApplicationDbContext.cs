using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRO401.Entities;

namespace PRO401
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                        .HasOne(m => m.ComunaResidencia)
                        .WithMany(t => t.UsuariosResidentes)
                        .HasForeignKey(m => m.ComunaResidenciaId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                        .HasOne(m => m.ComunaTrabajo)
                        .WithMany(t => t.UsuariosTrabajadores)
                        .HasForeignKey(m => m.ComunaTrabajoId)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Usuario>()
                        .HasIndex(x => x.Email)
                        .IsUnique();

            //modelBuilder.Entity<Encuesta>()
            //.HasOne(m => m.Usuario)
            //.WithOne(m => m.Encuesta)
            //.HasForeignKey<Encuesta>(m => m.UsuarioEmail)
            //.OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Comuna> Comuna { get; set; }
        public DbSet<Encuesta> Encuesta { get; set; }
        public DbSet<EstadoRegistro> EstadoRegistro { get; set; }
        public DbSet<TipoTrabajo> TipoTrabajo { get; set; }
        public DbSet<TipoTransporte> TipoTransporte { get; set; }
        public DbSet<Transporte> Transporte { get; set; }
    }
}
