using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica3.Datos;

namespace Practica3.Controllers
{
    public class cuentasController : Controller
    {
        private AYD1_P3_DBEntities db = new AYD1_P3_DBEntities();

        // GET: cuentas
        public ActionResult Index()
        {
            var cuenta = db.cuenta.Include(c => c.usuario);
            return View(cuenta.ToList());
        }

        // GET: cuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuenta cuenta = db.cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // GET: cuentas/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioCta = new SelectList(db.usuario, "CodUsuario", "NombreCompleto");
            return View();
        }

        // POST: cuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCuenta,MontoTotal,UsuarioCta")] cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.cuenta.Add(cuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioCta = new SelectList(db.usuario, "CodUsuario", "NombreCompleto", cuenta.UsuarioCta);
            return View(cuenta);
        }

      
        //GET: cuentas/SaldoUsuario
        public ActionResult SaldoUsuario(int? id) {


               
                cuenta cuenta1 = db.cuenta.Find(id);

                if (cuenta1 == null)
                {
                    return HttpNotFound();
                }

               
                    ViewBag.UsuarioCta = new SelectList(db.usuario, "CodUsuario", "NombreCompleto", cuenta1.UsuarioCta);
                    Session["SaldoCuenta"] = cuenta1.MontoTotal;
                    Session["CodCuenta"] = cuenta1.CodCuenta;
                    Session["UsuarioCta"] = cuenta1.UsuarioCta;
                    Session["Credito"] = cuenta1.credito;
                    Session["Debido"] = cuenta1.debito;

                    return RedirectToAction("Details", "cuentas");
               
            

            
                

            
        }


        // GET: cuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuenta cuenta = db.cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioCta = new SelectList(db.usuario, "CodUsuario", "NombreCompleto", cuenta.UsuarioCta);
            return View(cuenta);
        }



        // POST: cuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCuenta,MontoTotal,UsuarioCta")] cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioCta = new SelectList(db.usuario, "CodUsuario", "NombreCompleto", cuenta.UsuarioCta);
            return View(cuenta);
        }

        // GET: cuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuenta cuenta = db.cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // POST: cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cuenta cuenta = db.cuenta.Find(id);
            db.cuenta.Remove(cuenta);
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
