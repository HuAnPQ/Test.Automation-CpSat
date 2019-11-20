using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Test.Automation.PageModels;

namespace Test.Automation
{
    [TestClass]
    public class JsAlertTest
    {

        private RemoteWebDriver driver;
        private readonly string URL_JSALERT = "https://the-internet.herokuapp.com/javascript_alerts";

        [TestInitialize]
        public void IniciarDriver()
        {
            this.driver = new ChromeDriver("Drivers/");
        }


        [TestMethod]
        public void AlertInteraction()
        {
            this.driver.Navigate().GoToUrl(@URL_JSALERT);
            this.driver.FindElement(By.XPath("/html/body/div[2]/div/div/ul/li[1]/button")).Click();
            var alert = this.driver.SwitchTo().Alert();
            var alertText = alert.Text;
            alert.Accept();
            var messageTest = this.driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual("I am a JS Alert", alertText);
            Assert.AreEqual("You successfuly clicked an alert", messageTest);
            this.driver.FindElement(By.XPath("/html/body/div[2]/div/div/ul/li[2]/button")).Click();
            var secondAlert = this.driver.SwitchTo().Alert();
            var secondAlertTest = secondAlert.Text;
            secondAlert.Dismiss();
            var secondmessageTest = this.driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual("You clicked: Cancel", secondmessageTest);
            Assert.AreEqual("I am a JS Confirm", secondAlertTest);
            this.driver.FindElement(By.XPath("/html/body/div[2]/div/div/ul/li[3]/button")).Click();
            var thirdAlert = this.driver.SwitchTo().Alert();
            thirdAlert.SendKeys("Daniel");
            thirdAlert.Accept();
            var thirdMessageTest = this.driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual("You entered: Daniel", thirdMessageTest);
        }

        [TestMethod]
        public void AlertInteractionWithPageObjectModel()
        {
            var jsAlertPage = new JsAlertPaginaWeb(this.driver);
            jsAlertPage.ClickAlertButton();
            Assert.AreEqual("I am a JS Alert", jsAlertPage.GetAlertText());
            jsAlertPage.ClickOkOnAlert();
            Assert.AreEqual("You successfuly clicked an alert", jsAlertPage.GetResultText());
            jsAlertPage.ClickConfirmButton();
            Assert.AreEqual("I am a JS Confirm", jsAlertPage.GetAlertText());
            jsAlertPage.ClickCancelOnAlert();
            Assert.AreEqual("You clicked: Cancel", jsAlertPage.GetResultText());
            jsAlertPage.ClickPromptButton();
            jsAlertPage.WriteOnAlert("Hugo");
            jsAlertPage.ClickOkOnAlert();
            Assert.AreEqual("You entered: Hugo", jsAlertPage.GetResultText());
        }

        [TestCleanup]
        public void FinalizarDriver()
        {
            this.driver.Close();
        }
    }
}
