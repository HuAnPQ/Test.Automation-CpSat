using System;
using System.Collections.Generic;
using Automation.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]
namespace Test.Automation
{
    [TestClass]
    public class BusquedasPorDatosDeManeraParalela
    {

        private RemoteWebDriver driver;

        private readonly string URL_WIKIPEDIA = "https://www.wikipedia.org/";

        [TestInitialize]
        public void InicilizarDriver()
        {
            this.driver = new ChromeDriver("Drivers/");
        }

        [DataTestMethod]
        [DynamicData(nameof(ListarBusquedas), DynamicDataSourceType.Method)]
        public void BusquedaEnWikipediaPorDatos(Busqueda busqueda)
        {
            driver.Navigate().GoToUrl(URL_WIKIPEDIA);
            driver.FindElement(By.Id("searchInput")).SendKeys(busqueda.Descripcion);
            driver.FindElement(By.XPath("/html/body/div[2]/form/fieldset/button"))
                .Click();
            string titulo = driver.FindElement(By.Id("firstHeading")).Text;
            Assert.AreEqual(titulo, busqueda.PrimerResultado);
        }

        public static IEnumerable<object[]> ListarBusquedas()
        {
            ProveedorDeDatos provedorDeDatos = new ProveedorDeDatos();
            var productos = provedorDeDatos.ConsultarBusquedasDeExcel();
            foreach (var busqueda in productos)
            {
                yield return new object[] { busqueda };
            }
        }

        [TestCleanup]
        public void FinalizarDriver()
        {
            this.driver.Close();
        }
    }
}
