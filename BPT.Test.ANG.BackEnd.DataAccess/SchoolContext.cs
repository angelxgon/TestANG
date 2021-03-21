namespace BPT.Test.ANG.BackEnd.DataAccess
{
    using BPT.Test.ANG.BackEnd.DataAccess.DAO.Entitys;
    using Microsoft.EntityFrameworkCore;

    public partial class SchoolContext:DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        { 
        
        }
        public virtual DbSet<Asignacione> Asignaciones { get; set; }
        public virtual DbSet<AsignacionesEstudiante> AsignacionesEstudiantes { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-D0I9JI4S; Initial catalog=BTPAGC; user id=sa; password=ditec066;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Asignacione>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AsignacionesEstudiante>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idasignacion).HasColumnName("IDAsignacion");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
