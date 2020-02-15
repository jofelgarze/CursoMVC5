using System.Collections.Generic;

namespace escuela.webapp.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}