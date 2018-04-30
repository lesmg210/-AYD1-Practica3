using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Practica3.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void Contact()
        {
            HomeController home = new HomeController();

            ViewResult resultado = home.Contact() as ViewResult;

            Assert.IsNotNull(resultado);

        }
    }
}