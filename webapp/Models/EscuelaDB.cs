namespace webapp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EscuelaDB : DbContext
    {
        public EscuelaDB()
            : base("name=EscuelaDB")
        {
        }

        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .Property(e => e.Materia)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Estudiante)
                .WithMany(e => e.Curso)
                .Map(m => m.ToTable("CursoEstudiantes").MapLeftKey("CursoId").MapRightKey("Identificacion"));

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.TipoIdentificacion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .HasMany(e => e.Curso)
                .WithRequired(e => e.Profesor)
                .WillCascadeOnDelete(false);
        }
    }
}
