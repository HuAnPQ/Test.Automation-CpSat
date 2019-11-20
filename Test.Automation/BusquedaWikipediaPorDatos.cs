using System;
using System.Collections.Generic;
using Automation.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test.Automation
{
    [TestClass]
    public class BusquedaWikipediaPorDatos
    {
        private static IWebDriver driver;
        private readonly string URL_WIKIPEDIA = "https://www.wikipedia.org/";

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            driver = new ChromeDriver("Drivers/");
        }

        [DataTestMethod]
        [DynamicData(nameof(ListarBusquedas), DynamicDataSourceType.Method)]
        public void BusquedaEnWikipediaPorData(Busqueda busqueda)
        {
            driver.Navigate().GoToUrl(@URL_WIKIPEDIA);
            driver.FindElement(By.Id("searchInput")).SendKeys(busqueda.Descripcion);
            driver.FindElement(By.XPath("/html/body/div[2]/form/fieldset/button"))
                .Click();
            string titulo = driver.FindElement(By.Id("firstHeading")).Text;
            Assert.AreEqual(titulo, busqueda.PrimerResultado);
        }

        private static IEnumerable<object[]> ListarBusquedas()
        {
            var proveedorDeDatos = new ProveedorDeDatos();
            var busquedas = proveedorDeDatos.ConsultarBusquedasDeExcel();
            foreach (var busqueda in busquedas)
            {
                yield return new object[] { busqueda };
            }
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            driver.Close();
        }
    }
}
