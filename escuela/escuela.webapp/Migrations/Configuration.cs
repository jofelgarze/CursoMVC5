namespace escuela.webapp.Migrations
{
    using escuela.webapp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<escuela.webapp.Models.EscuelaContextDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(escuela.webapp.Models.EscuelaContextDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (context.Materias.Count() == 0)
            {

                var materia = new Materia
                {
                    Nombre = "Programacion I"
                };

                for (int i = 0; i < 20; i++)
                {
                    context.Estudiantes.Add(new Estudiante
                    {
                        Nombres = "Nombre " + i,
                        Apellidos = "Apellido " + i,
                        Identificacion = "09208155" + i.ToString("00"),
                        TipoIdentificacion = TipoIdentificacionEnum.Cedula,
                        FechaNacimiento = DateTime.UtcNow.AddYears(10 + (i * -1))
                    });
                }

                context.Materias.Add(materia);
                context.SaveChanges();
            }


            
            base.Seed(context);
        }
    }
}

