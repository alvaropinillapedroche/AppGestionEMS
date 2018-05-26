using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppGestionEMS.Models;
using Microsoft.AspNet.Identity;

namespace AppGestionEMS.Controllers
{
    [Authorize(Roles = "profesor")]
    public class MatriculasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Matriculas
        public ActionResult Index()
        {
            int grupo = getGrupoClase();
            var matriculas = db.Matriculas.Include(m => m.alumno).Include(m => m.curso).Include(m => m.grupo).Where(p => p.grupoId == grupo).ToList();
            return View(matriculas.ToList());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            return View(matriculas);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.alumnoId = new SelectList(db.Users, "Id", "Name");
            ViewBag.cursoId = new SelectList(db.Cursos, "Id", "promocion");
            ViewBag.grupoId = new SelectList(db.GrupoClases, "Id", "nombre");
            return View();
        }

        // POST: Matriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,alumnoId,cursoId,grupoId,fecha")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matriculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.alumnoId = new SelectList(db.Users, "Id", "Name", matriculas.alumnoId);
            ViewBag.cursoId = new SelectList(db.Cursos, "Id", "promocion", matriculas.cursoId);
            ViewBag.grupoId = new SelectList(db.GrupoClases, "Id", "nombre", matriculas.grupoId);
            return View(matriculas);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.alumnoId = new SelectList(db.Users, "Id", "Name", matriculas.alumnoId);
            ViewBag.cursoId = new SelectList(db.Cursos, "Id", "promocion", matriculas.cursoId);
            ViewBag.grupoId = new SelectList(db.GrupoClases, "Id", "nombre", matriculas.grupoId);
            return View(matriculas);
        }

        // POST: Matriculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,alumnoId,cursoId,grupoId,fecha")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matriculas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.alumnoId = new SelectList(db.Users, "Id", "Name", matriculas.alumnoId);
            ViewBag.cursoId = new SelectList(db.Cursos, "Id", "promocion", matriculas.cursoId);
            ViewBag.grupoId = new SelectList(db.GrupoClases, "Id", "nombre", matriculas.grupoId);
            return View(matriculas);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            return View(matriculas);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matriculas matriculas = db.Matriculas.Find(id);
            db.Matriculas.Remove(matriculas);
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

        private int getGrupoClase()
        {
            string currentUserId = User.Identity.GetUserId();
            var grupos = db.AsignacionDocentes.Where(p => p.profesorId == currentUserId).ToList();
            if (grupos.Count == 0)
                return -1;
            else
                return grupos.First().grupo.Id;
        }
    }
}
