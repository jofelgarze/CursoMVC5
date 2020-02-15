using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace escuela.webapp.Models
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(150)]
        public string Apellidos { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }

    }
}