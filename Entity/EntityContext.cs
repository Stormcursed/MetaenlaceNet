using Microsoft.EntityFrameworkCore;

namespace MetaenlaceNet.Entity

{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {
          
        }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ORDENADOR\SQLEXPRESS;Database=METAENLACE_HOSP;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder) 
        {
            var citas = modelbuilder.Entity<Cita>();
            citas.HasOne<Medico>(s => s.medico)
                 .WithMany(s => s.citas)
                 .OnDelete(DeleteBehavior.NoAction);
            citas.HasOne<Paciente>(s => s.paciente)
                 .WithMany(s => s.citas)
                 .OnDelete(DeleteBehavior.NoAction);
                 
            citas.ToTable("Cita");
            citas.HasKey(s => s.CitaId);

            var pacientes = modelbuilder.Entity<Paciente>();
            /*pacientes.HasMany(s => s.citas)
                     .WithOne(s => s.paciente)
                     .OnDelete(DeleteBehavior.NoAction);*/
            pacientes.ToTable("Paciente");

            var medicos = modelbuilder.Entity<Medico>();
            /*medicos.HasMany(s => s.citas)
                   .WithOne(s => s.medico)
                   .OnDelete(DeleteBehavior.NoAction);*/
            medicos.HasMany(s => s.pacientes)
                   .WithMany(s => s.medicos);
            medicos.ToTable("Medico");

            var diagnosticos = modelbuilder.Entity<Diagnostico>();
            diagnosticos.ToTable("Diagnostico");
            diagnosticos.HasOne(s => s.cita)
                 .WithOne(s => s.diagnostico)
                 .HasForeignKey<Diagnostico>(s => s.DiagnosticoId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.NoAction);
            diagnosticos.HasKey(s => s.DiagnosticoId);  

            var usuarios = modelbuilder.Entity<Usuario>();
            usuarios.ToTable("Usuario");
            usuarios.HasKey(s => s.UsuarioId);
        }
        
    }
}
