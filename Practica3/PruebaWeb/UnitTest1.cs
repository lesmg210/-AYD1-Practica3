using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3.Controllers;
using Practica3.Models;

namespace PruebaWeb
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {


            Practica3.Datos.usuario prueba = new Practica3.Datos.usuario();
            usuariosController log = new usuariosController();

            prueba.CodUsuario = 1111;
            prueba.Contraseña = "1234";
            prueba.NombreUsuario = "Luiskr1993";

            
        }
    }
}
