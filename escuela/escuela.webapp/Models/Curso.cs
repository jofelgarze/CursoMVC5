using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace escuela.webapp.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        [DataType(DataType.Time)]
        public DateTime HoraInicio { get; set; }
        [DataType(DataType.Time)]
        public DateTime HoraFin { get; set; }

        public int MateriaId { get; set; }
        public virtual Materia Materia { get; set; }


        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}