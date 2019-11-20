using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace Test.Automation
{
    [TestClass]
    public class AnnaunivEdu_Firefox
    {
        private RemoteWebDriver driver;
        private readonly string URL_ANNAUNIV = "https://www.annauniv.edu/";

        [TestInitialize]
        public void InicilizarDriver()
        {
            this.driver = new FirefoxDriver("Drivers/");
        }


        [TestMethod]
        public void TestOceanManagementEnAnnauniv()
        {
            /**
             * 1. https://www.annauniv.edu/
                2. hacer click en "departments"
                3. Hover en Civil Engineering -> Actions
                4. Click en Institute for Ocean Management
                5. Verificar el titulo
             * **/
            string tituloDeseado = "Institute For Ocean Management";
            driver.Navigate().GoToUrl(@URL_ANNAUNIV);
            driver.FindElement(By.XPath("/html/body/table/tbody/tr[1]/td[1]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td[5]/div/a"))
                .Click();

            IWebElement civil = driver.FindElement(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[3]/td/table/tbody/tr[2]/td[2]/table/tbody/tr/td/table/tbody/tr[2]/td[2]/div/a"));
            new Actions(driver).MoveToElement(civil).Build().Perform();
            Thread.Sleep(10000);
            IWebElement ocean = driver.FindElement(By.Id("menuItemText32"));
            new Actions(driver).MoveToElement(ocean).Click().Build().Perform();
            Thread.Sleep(10000);

            string titulo = driver.Title;
            Assert.IsTrue(titulo.Contains(tituloDeseado));
        }

        [TestCleanup]
        public void FinalizarDriver()
        {
            this.driver.Close();
        }

    }
}
