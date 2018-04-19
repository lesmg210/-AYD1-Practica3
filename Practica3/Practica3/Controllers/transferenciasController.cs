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
    public class transferenciasController : Controller
    {
        private AYD1_P3_DBEntities db = new AYD1_P3_DBEntities();

        // GET: transferencias
        public ActionResult Index()
        {
            var transferencia = db.transferencia.Include(t => t.cuenta).Include(t => t.cuenta1);
            return View(transferencia.ToList());
        }

        // GET: transferencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transferencia transferencia = db.transferencia.Find(id);
            if (transferencia == null)
            {
                return HttpNotFound();
            }
            return View(transferencia);
        }

        // GET: transferencias/Create
        public ActionResult Create()
        {
            ViewBag.CtaDestino = new SelectList(db.cuenta, "CodCuenta", "CodCuenta");
            ViewBag.CtaFuente = new SelectList(db.cuenta, "CodCuenta", "CodCuenta");
            return View();
        }

        // POST: transferencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodTransferencia,CtaDestino,CtaFuente,Monto")] transferencia transferencia)
        {
            if (ModelState.IsValid)
            {
                db.transferencia.Add(transferencia);
                cuenta cuentaDestino = db.cuenta.Find(transferencia.CtaDestino);
                cuenta cuentaFuente = db.cuenta.Find(transferencia.CtaFuente);

                cuentaDestino.MontoTotal = cuentaDestino.MontoTotal + transferencia.Monto;
                cuentaFuente.MontoTotal = cuentaFuente.MontoTotal - transferencia.Monto;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CtaDestino = new SelectList(db.cuenta, "CodCuenta", "CodCuenta", transferencia.CtaDestino);
            ViewBag.CtaFuente = new SelectList(db.cuenta, "CodCuenta", "CodCuenta", transferencia.CtaFuente);
            return View(transferencia);
        }

        // GET: transferencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transferencia transferencia = db.transferencia.Find(id);
            if (transferencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.CtaDestino = new SelectList(db.cuenta, "CodCuenta", "CodCuenta", transferencia.CtaDestino);
            ViewBag.CtaFuente = new SelectList(db.cuenta, "CodCuenta", "CodCuenta", transferencia.CtaFuente);
            return View(transferencia);
        }

        // POST: transferencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodTransferencia,CtaDestino,CtaFuente,Monto")] transferencia transferencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transferencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CtaDestino = new SelectList(db.cuenta, "CodCuenta", "CodCuenta", transferencia.CtaDestino);
            ViewBag.CtaFuente = new SelectList(db.cuenta, "CodCuenta", "CodCuenta", transferencia.CtaFuente);
            return View(transferencia);
        }

        // GET: transferencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transferencia transferencia = db.transferencia.Find(id);
            if (transferencia == null)
            {
                return HttpNotFound();
            }
            return View(transferencia);
        }

        // POST: transferencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transferencia transferencia = db.transferencia.Find(id);
            db.transferencia.Remove(transferencia);
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
