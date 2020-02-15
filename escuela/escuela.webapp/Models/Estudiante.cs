using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace escuela.webapp.Models
{
    [Table("Estudiante")]
    public class Estudiante
    {
        [Key]
        public string Identificacion { get; set; }

        [Required]
        [EnumDataType(typeof(TipoIdentificacionEnum))]
        public TipoIdentificacionEnum TipoIdentificacion { get; set; }

        [Required]
        [Column("Nombres", TypeName = "varchar")]
        [MaxLength(150)]
        public string Nombres { get; set; }

        [Required]
        [Column("Apellidos", TypeName = "varchar")]
        [MaxLength(150)]
        public string Apellidos { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [NotMapped]
        public string NombreCompleto {
            get {
                return string.Concat(this.Nombres, " ", this.Apellidos);
            }
        }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}