using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using Test.Automation.Pages;

namespace Test.Automation
{
    [TestClass]
    public class InterBankPeruTest
    {

        private RemoteWebDriver driver;

        [TestInitialize]
        public void IniciarDriver()
        {
            this.driver = new ChromeDriver("Drivers/");
        }

        [TestMethod]
        public void LlenarFormularioParaCrearCuenta()
        {
            InterBankPeru interbankPage = new InterBankPeru();
            this.driver.Navigate().GoToUrl(@"https://interbank.pe/");

            PageFactory.InitElements(this.driver, interbankPage);

            interbankPage.CrearCuenta.Click();
            interbankPage.NumeroDNI.SendKeys("26260606");
            Thread.Sleep(1000);
            interbankPage.Celular.SendKeys("990147240");
            Thread.Sleep(1000);
            interbankPage.Email.SendKeys("hugoponcequiroz@gmail.com");
            Thread.Sleep(1000);
            interbankPage.ButtonEnviar.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(true);
        }

        [TestCleanup]
        public void FinalizarDriver()
        {
            this.driver.Close();
        }
    }
}
