using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3.Controllers;
using System.Web.Mvc;

namespace Unitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            usuariosController usuarios = new usuariosController();
            ViewResult vista = usuarios.Login() as ViewResult;

            Assert.IsNotNull(vista);
        }
    }
}
