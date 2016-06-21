using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.Commons;
using MiPrimerProyectoMVC.Tags;

namespace MiPrimerProyectoMVC.Controllers
{
    [AutenticadoAttribute]
    public class ReportesController : Controller
    {
      

        private TestContext db = new TestContext();

        // GET: Reportes
        public ActionResult Index()
        {
            var reportes = db.Reportes.Include(r => r.Equipo).Include(r => r.Usuario);
            ViewBag.Usuario = Reportantes();
            return View(reportes.ToList());
        }

        public IEnumerable<Usuario> Reportantes() {
            try {
                var info = from u in db.Usuario
                           join r in db.Reportes
                           on u.UserId equals r.UserId_Reporte
                           select u;
                return info.ToList();
            }
            catch (Exception e) {
                return null;
            }
        }
       

        // GET: Reportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reportes.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            return View(reporte);
        }

        // GET: Reportes/Create
        public ActionResult Create()
        {
            var usuarios = db.Usuario                
                .ToList()
                .Select(s => new
                {
                    UserId = s.UserId,
                    Nombre =  s.Nombre +" "+ s.Apellido
                });
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "Nombre");
            ViewBag.EquipoId = new SelectList(db.Equipos, "EquipoId", "NombreEquipo");
            ViewBag.UserId = new SelectList(usuarios, "UserId", "Nombre");
            return View();
        }

        

        public ActionResult equipos(int id)
        {
            var equipos = db.Equipos.Where(x => x.SalaId==id);
            return Json(new SelectList(equipos,
                "EquipoId", "NombreEquipo"), JsonRequestBehavior.AllowGet
                );
        }



        // POST: Reportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReporteId,Fecha_Reporte,Fecha_Realizado,Descripcion,Estado,UserId,EquipoId,User_RealizadoId,UserId_Reporte")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                reporte.UserId_Reporte = FrontUser.Get().UserId;
                reporte.Fecha_Reporte = DateTime.Now;
                reporte.Fecha_Realizado = DateTime.Now;
                if (!FrontUser.TienePermiso(RolesPermisos.puede_asignar_tarea)) {
                    reporte.UserId = FrontUser.Get().UserId;
                }
                reporte.Estado = "Pendiente";
                db.Reportes.Add(reporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipoId = new SelectList(db.Equipos, "EquipoId", "NombreEquipo", reporte.EquipoId);
            ViewBag.UserId = new SelectList(db.Usuario, "UserId", "UserName", reporte.UserId);
            return View(reporte);
        }

        // GET: Reportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reportes.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipoId = new SelectList(db.Equipos, "EquipoId", "NombreEquipo", reporte.EquipoId);
            ViewBag.UserId = new SelectList(db.Usuario, "UserId", "UserName", reporte.UserId);
            return View(reporte);
        }

        // POST: Reportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReporteId,Fecha_Reporte,Fecha_Realizado,Descripcion,Estado,UserId,EquipoId,User_RealizadoId,UserId_Reporte")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                reporte.Fecha_Realizado = DateTime.Now;
                reporte.User_RealizadoId = FrontUser.Get().UserId;
                db.Entry(reporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipoId = new SelectList(db.Equipos, "EquipoId", "NombreEquipo", reporte.EquipoId);
            ViewBag.UserId = new SelectList(db.Usuario, "UserId", "UserName", reporte.UserId);
            return View(reporte);
        }

        // GET: Reportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reportes.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            return View(reporte);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reporte reporte = db.Reportes.Find(id);
            db.Reportes.Remove(reporte);
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
