using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace Test.Automation.Specs
{
    [Binding]
    public class EsUnaPruebaParaVerLaEdicionDeWikipediaSteps
    {
        private RemoteWebDriver driver;

        [Given(@"Estoy en la pagina de Wikipedia Produbanco")]
        public void GivenEstoyEnLaPaginaDeWikipediaProdubanco()
        {
            this.driver = new ChromeDriver(@"C:\Users\Administrador\source\repos\Test.Automation-CpSat\Test.Automation\Drivers\");
            this.driver.Navigate().GoToUrl(@"https://en.wikipedia.org/wiki/Produbanco");
        }
        
        [Given(@"Haga Click En Editar")]
        public void GivenHagaClickEnEditar()
        {
            this.driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div[3]/div[1]/ul/li[2]/a"))
                .Click();
        }
        
        [Then(@"El Titulo de la pagina de edicion debaria Incluir a la palabra ""(.*)""")]
        public void ThenElTituloDeLaPaginaDeEdicionDebariaIncluirALaPalabra(string p0)
        {
            string titleText = this.driver.FindElement(By.Id("firstHeading")).Text;
            Assert.IsTrue(titleText.Contains(p0));
            this.driver.Close();
            this.driver.Dispose();
        }
    }
}
