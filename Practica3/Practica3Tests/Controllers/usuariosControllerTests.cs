using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3.Controllers;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica3.Datos;
using System.Net;
using Practica3;
using System.Web.Mvc;

namespace Practica3.Controllers.Tests
{
    [TestClass()]
    public class usuariosControllerTests
    {
        
        [TestMethod()]
        public void verificarUsuarioTest()
        {

            usuariosController usuarios = new usuariosController();
            
            
            
            usuario usuarioPrueba = new usuario()
            {
                CodUsuario = 1111,
                NombreUsuario = "Luiskr1993",
                NombreCompleto = "Luis Carlos Valiente Salazar",
                Contraseña = "1234",
                CorreoElectronico = "luiskr1993@gmail.com"            
                
            };
            Boolean resultado = usuarios.verificarUsuario(usuarioPrueba);

            //ViewResult resultado = usuarios.Login(usuarioPrueba);
            
            if (resultado == false)
            {
                //ViewResult vista = usuarios.Create() as ViewResult;

                Assert.Fail();
            }
   

        }

        [TestMethod()]
        public void Login()
        {
            usuariosController usuarios = new usuariosController();

            ViewResult vista = usuarios.Login() as ViewResult;

            Assert.IsNotNull(vista);
            
        }

        [TestMethod()]
        public void Registro()
        {
            usuariosController usuarios = new usuariosController();

            ViewResult vista = usuarios.Create() as ViewResult;

            Assert.IsNotNull(vista);

        }
    }
}