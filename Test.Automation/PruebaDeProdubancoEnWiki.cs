using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test.Automation
{
    [TestClass]
    public class PruebaDeProdubancoEnWiki
    {
        IWebDriver webDriver;

        [TestInitialize]
        public void IniciarDriver()
        {
            this.webDriver = new ChromeDriver("Drivers/");
        }

        [TestCleanup]
        public void EliminarElProcesoDelDriver()
        {
            this.webDriver.Close();
        }

        [Ignore]
        [TestMethod]
        public void TituloDeEdicionCorrecto()
        {
            webDriver.Navigate().GoToUrl(@"https://en.wikipedia.org/wiki/Produbanco");
            webDriver.FindElement(By.XPath("/html/body/div[5]/div[1]/div[3]/div[1]/ul/li[2]/a")).Click();
            Thread.Sleep(2000);
            string titulo = webDriver.FindElement(By.ClassName("firstHeading")).Text;
            Assert.IsTrue(titulo.Contains("Produbanco"));
        }

        [Ignore]
        [TestMethod]
        public void BuscarTituloVolcanPichincha()
        {
            webDriver.Navigate().GoToUrl(@"https://es.wikipedia.org/wiki/Wikipedia:Portada");
            webDriver.FindElement(By.Id("searchInput")).SendKeys("Pichincha");
            webDriver.FindElement(By.Id("searchButton")).Click();

            webDriver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[4]/div/ul/li[2]/b/a")).Click();

            string titulo = webDriver.FindElement(By.Id("firstHeading")).Text;
            Assert.IsTrue(titulo.Contains("Volcán Pichincha"));
        }


        [TestMethod]
        public void PracticaToastr()
        {
            string MensajeHola = "Hola Hugo";

            webDriver.Navigate().GoToUrl(@"https://codeseven.github.io/toastr/demo.html");
            webDriver.FindElement(By.Id("message")).SendKeys(MensajeHola);
            webDriver.FindElement(By.XPath("/html/body/section/div/div[1]/div[2]/div[1]/div/label[2]/input")).Click();

            //webDriver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[4]/div/ul/li[2]/b/a")).Click();
            webDriver.FindElement(By.Id("positionGroup"))
                .FindElement(By.TagName("label.radio:nth-child(9) > input:nth-child(1)")).Click();
            Thread.Sleep(3000);
            webDriver.FindElement(By.Id("showtoast")).Click();
            string toastMensaje = webDriver.FindElement(By.Id("toast-container"))
                .FindElement(By.ClassName("toast-message")).Text;
            Assert.IsTrue(toastMensaje.Contains(MensajeHola));
        }

    }
}
