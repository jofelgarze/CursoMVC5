using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webapp.Models;

namespace webapp.Controllers
{
    public class EstudiantesController : Controller
    {
        private EscuelaDB db = new EscuelaDB();

        // GET: Estudiantes
        public ActionResult Index()
        {
            return View(db.Estudiante.ToList());
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificacion,TipoIdentificacion,Nombres,Apellidos,FechaNacimiento,Activo")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Estudiante.Add(estudiante);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // ... bloque de logica de negocio para determinar el error exacto para pasar por msj

                    ModelState.AddModelError("Identificacion","El estudiante ya está registrado.");

                    ModelState.AddModelError(string.Empty, "Hay un problema para guardar el registro");


                }
                
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }

            List<webapp.Models.TipoIdentificacionDTO> lista = new List<webapp.Models.TipoIdentificacionDTO>();
            lista.Add(new webapp.Models.TipoIdentificacionDTO { Codigo = "CED", Nombre = "Cédula" });
            lista.Add(new webapp.Models.TipoIdentificacionDTO { Codigo = "RUC", Nombre = "Ruc" });
            lista.Add(new webapp.Models.TipoIdentificacionDTO { Codigo = "PAS", Nombre = "Pasporte" });
            ViewBag.lista = new SelectList(lista, "Codigo", "Nombre", estudiante.TipoIdentificacion);
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificacion,TipoIdentificacion,Nombres,Apellidos,FechaNacimiento,Activo")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            db.Estudiante.Remove(estudiante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
