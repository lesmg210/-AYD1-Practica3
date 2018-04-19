using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica3.Datos;

namespace Practica3.Controllers.Tests
{
    [TestClass()]
    public class usuariosControllerTests
    {
        [TestMethod()]
        public void LoginTest()
        {

            Assert.Fail();
        }

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
            Assert.Fail();
            /*
            Boolean resultado = usuarios.verificarUsuario(usuarioPrueba);

            if (resultado == false)
            {
                
            }*/
           
            
        }
    }
}