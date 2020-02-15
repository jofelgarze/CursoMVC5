using escuela.webapp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace escuela.webapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new EscuelaContextDb()) {
                var identificacion = new SqlParameter("@identificacion", "0920815500");
                var tipoIdentificacion = new SqlParameter("@tipoIdentificacion", Enum.GetName(typeof(TipoIdentificacionEnum), TipoIdentificacionEnum.Cedula));
                var nota1 = new SqlParameter("@nota1", 7.34);
                var nota2 = new SqlParameter("@nota2", 9.45);

                context.Database.ExecuteSqlCommand("ingresarNotaPorIdentificacion @identificacion, @tipoIdentificacion, @nota1, @nota2", identificacion, tipoIdentificacion, nota1, nota2);

                var result = context.Database.SqlQuery<NotasCurso>("consultaCursosAprobadosPorIdentificacion @p0, @p1", parameters: new[] { "0920815503", Enum.GetName(typeof(TipoIdentificacionEnum), TipoIdentificacionEnum.Cedula) });
                result.FirstOrDefault();
                Console.WriteLine(result.FirstOrDefault());
            }

                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}