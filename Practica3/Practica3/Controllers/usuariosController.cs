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
    public class usuariosController : Controller
    {
        private AYD1_P3_DBEntities db = new AYD1_P3_DBEntities();

        // GET: usuarios
        public ActionResult Index()
        {
            return View(db.usuario.ToList());
        }

        // GET: usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

       

        // POST: usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodUsuario,NombreCompleto,NombreUsuario,CorreoElectronico,Contraseña")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: usuarios/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: usuarios/Login
        //Método para consultar los datos de inicio de sesiòn de usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "CodUsuario,NombreUsuario,Contraseña")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //db.usuario.Add(usuario);
                
                usuario usuario1 = db.usuario.Find(usuario.CodUsuario);

                if (usuario1 == null) {
                    //return View("Account");
                    return RedirectToAction("ErrorUsuario");
                }

                if (usuario1.NombreUsuario == usuario.NombreUsuario)
                {
                    if (usuario1.Contraseña == usuario.Contraseña)
                    {
                        return RedirectToAction("Valido");
                    }
                    else {
                       
                        return RedirectToAction("ErrorUsuario");
                    }

                }
                else {
                    return RedirectToAction("ErrorUsuario");
                }
                //return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: usuarios/ErrorUsuario
        public ActionResult ErrorUsuario()
        {
            return View();
        }

        // GET: usuarios/Valido
        public ActionResult Valido()
        {     
            return View();
        }


        // GET: usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodUsuario,NombreCompleto,NombreUsuario,CorreoElectronico,Contraseña")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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
