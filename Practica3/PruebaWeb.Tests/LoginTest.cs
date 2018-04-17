using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3.Controllers;
using Practica3.Datos;

namespace PruebaWeb.Tests
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void TestMethod1()
        {
           
            var usuarios = new usuariosController();
            var usuario1 = new usuario() {
                CodUsuario = 1111,
                NombreUsuario = "Luiskr1993",
                Contraseña = "1234"
            };

            Boolean resultado;

            resultado = usuarios.Login2(usuario1);


        }
    }
}
