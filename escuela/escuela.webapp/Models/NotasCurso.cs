using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace escuela.webapp.Models
{
    public class NotasCurso
    {
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }

        [NotMapped]
        public bool Aprobado {
            get {
                return ((Nota1 + Nota2) / 2) >= 7;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} , Nota 1: {1}, Nota 2: {2}", Identificacion, Nota1, Nota2);
        }
    }
}