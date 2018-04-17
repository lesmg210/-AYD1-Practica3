using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3.Controllers;

namespace PruebasWeb
{
    [TestClass]
    public class PruebaLogin
    {
        [TestMethod]
        public void TestMethod1()
        {
            var prueba = new Practica3.Datos.usuario();
            var log = new usuariosController();

            prueba.CodUsuario = 1111;
            prueba.Contraseña = "1234";
            prueba.NombreUsuario = "Luiskr1993";

            Boolean resultado;

            resultado = log.Login2(prueba);


        }
    }
}
