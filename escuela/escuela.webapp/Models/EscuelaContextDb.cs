namespace escuela.webapp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.SqlClient;
    using System.Linq;

    public class EscuelaContextDb : ApplicationDbContext
    {
        public EscuelaContextDb()
            : base()
        {
            //Database.SetInitializer<EscuelaContextDb>(new CreateDatabaseIfNotExists<EscuelaContextDb>());
            //Database.SetInitializer<EscuelaContextDb>(new DropCreateDatabaseIfModelChanges<EscuelaContextDb>());
            //Database.SetInitializer<EscuelaContextDb>(new DropCreateDatabaseAlways<EscuelaContextDb>());
            //Database.SetInitializer<EscuelaContextDb>(new EscuelaDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }

    }
    
}