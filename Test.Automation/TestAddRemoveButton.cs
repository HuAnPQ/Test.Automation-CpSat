using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using Test.Automation.Pages;

namespace Test.Automation
{
    [TestClass]
    public class TestAddRemoveButton
    {

        private RemoteWebDriver driver;

        [TestInitialize]
        public void IniciarDriver()
        {
            this.driver = new ChromeDriver("Drivers/");
        }

        [TestMethod]
        public void AddTenElements()
        {
            AddRemoveElements addRemoteElementsPage = new AddRemoveElements();
            this.driver.Navigate().GoToUrl(@"https://the-internet.herokuapp.com/add_remove_elements/");

            PageFactory.InitElements(this.driver, addRemoteElementsPage);

            Enumerable.Range(1, 20).ToList().ForEach(number =>
            {
                addRemoteElementsPage.AddElementButton.Click();
                Thread.Sleep(500);
            });
            var newButtons = addRemoteElementsPage.NewButtons;
            Assert.AreEqual(newButtons.Count, 20);
            newButtons.ToList().ForEach(button => {
                button.Click();
                Thread.Sleep(500);
            });
        }

        [TestCleanup]
        public void FinalizarDriver()
        {
            this.driver.Close();
        }

    }
}
