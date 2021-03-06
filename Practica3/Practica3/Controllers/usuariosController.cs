﻿using System;
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
                if (db.usuario.Any(x => x.NombreUsuario == usuario.NombreUsuario))
                {
                    ViewBag.DuplicateMessage = "El nombre de usuario ya existe!!";

                    return View("Create", usuario);
                }
                
                db.usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Usuario registrado correctamente!!!";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //Metodo que verifica la existencia del usuario
        public Boolean verificarUsuario(usuario usuario)
        {
            usuario usuario1 = db.usuario.Find(usuario.CodUsuario);

            if (usuario1 == null)
            {
                return false;
            }


            if (usuario1.NombreUsuario == usuario.NombreUsuario)
            {
                if (usuario1.Contraseña == usuario.Contraseña)
                {
                    ViewBag.SuccessMessage = "Usuario validado correctamente!!";

                    Session["CodUsuario"] = usuario1.CodUsuario;
                    Session["NombreUsuario"] = usuario1.NombreUsuario;
                    Session["NombreCompleto"] = usuario1.NombreCompleto;



                    return true;
                }
                else
                {

                    return false;
                }

            }
            else
            {
                return false;
            }
 
        }

        //Verifica si es usuario administrador
        public Boolean VerificarAdministrador(usuario usuario)
        {
            usuario usuario1 = db.usuario.Find(usuario.CodUsuario);

            if (usuario1.CodUsuario == 9999)
            {
                if (usuario1.NombreUsuario == "admin" && usuario1.Contraseña == "admin")
                {
                    Session["NombreUsuario"] = usuario1.NombreUsuario;

                    return true;
                }
            }

            return false;
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

                Boolean usuarioAdmin, usuarioNormal;
                usuarioAdmin = VerificarAdministrador(usuario);

                if (usuarioAdmin == true)
                {
                    return RedirectToAction("Administrador", "Home");
                }
                else {
                    usuarioNormal = verificarUsuario(usuario);

                    if (usuarioNormal == true)
                    {
                        return RedirectToAction("Valido");
                    }
                }
                

                /*
                usuario usuario1 = db.usuario.Find(usuario.CodUsuario);

                if (usuario1 == null) {
                    //return View("Account");
                    return RedirectToAction("ErrorUsuario");
                }

                if (usuario1.CodUsuario == 9999) {
                    if (usuario1.NombreUsuario == "admin" && usuario1.Contraseña == "admin") {
                        Session["NombreUsuario"] = usuario1.NombreUsuario;
                            
                            return RedirectToAction("Administrador", "Home");
                    }
                }

                if (usuario1.NombreUsuario == usuario.NombreUsuario)
                {
                    if (usuario1.Contraseña == usuario.Contraseña)
                    {
                        ViewBag.SuccessMessage = "Usuario validado correctamente!!";

                        Session["CodUsuario"] = usuario1.CodUsuario;
                        Session["NombreUsuario"] = usuario1.NombreUsuario;
                        Session["NombreCompleto"] = usuario1.NombreCompleto;

                        

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
                */
            }

            return View(usuario);
        }


        

        // POST: usuarios/Login2
        //Método para consultar los datos de inicio de sesiòn de usuario

        public Boolean Login2([Bind(Include = "CodUsuario,NombreUsuario,Contraseña")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //db.usuario.Add(usuario);

                usuario usuario1 = db.usuario.Find(usuario.CodUsuario);

                if (usuario1 == null)
                {
                    //return View("Account");
                    return false;
                }

                if (usuario1.NombreUsuario == usuario.NombreUsuario)
                {
                    if (usuario1.Contraseña == usuario.Contraseña)
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }

                }
                else
                {
                    return true;
                }
                //return RedirectToAction("Index");
            }

            return false;
        }

        //POST usuario/LogOut
        public ActionResult LogOut() {

            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        //PERFIL DE USUARIO
        public ActionResult Perfil() {
            return View();
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
