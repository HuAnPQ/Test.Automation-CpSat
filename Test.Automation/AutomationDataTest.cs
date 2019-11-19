using System;
using System.Linq;
using Automation.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Automation
{
    [TestClass]
    public class AutomationDataTest
    {
        [TestMethod]
        public void BusquedasDesdeExcel()
        {
            var proveedorDeDatos = new ProveedorDeDatos();
            var busquedas = proveedorDeDatos.ConsultarBusquedasDeExcel();
            Assert.IsTrue(busquedas.Count() > 0);
        }
    }
}
