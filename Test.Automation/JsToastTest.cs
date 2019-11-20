using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Test.Automation.PageModels;

namespace Test.Automation
{
    [TestClass]
    public class JsToastTest
    {
        private RemoteWebDriver driver;

        [TestInitialize]
        public void IniciarDriver()
        {
            this.driver = new ChromeDriver("Drivers/");
        }

        [TestMethod]
        public void TestMethod_ToastWithPageObjectModel()
        {
            JsToastrPOM jsToastPOM = new JsToastrPOM(this.driver);

            string titulo = "Titulo del Contenedor";
            string message = "Hola Hugo";

            jsToastPOM.WriteOnTitle(titulo);
            jsToastPOM.ClickButtonShowToast();
            Thread.Sleep(5000);
            Assert.AreEqual(titulo, jsToastPOM.GetToastTitleText());

            jsToastPOM.WriteOnMessage("Hola Hugo");
            jsToastPOM.ClickButtonShowToast();
            Thread.Sleep(5000);
            Assert.IsTrue(jsToastPOM.GetToastMessageText().Contains(message));

            jsToastPOM.ClickButtonClearToasts();
            jsToastPOM.ClickCheckOnCloseButton();
            jsToastPOM.ClickButtonShowToast();
            Thread.Sleep(5000);
            Assert.IsTrue(jsToastPOM.GetButtonToastClose() != null);
        }

        [TestMethod]
        public void TestMethod_EjercicioShowsAlert()
        {
            JsToastrPOM jsToastPOM = new JsToastrPOM(this.driver);

            string message = "Hola Hugo";
            string alertText = "You can perform some custom action after a toast goes away";

            jsToastPOM.WriteOnMessage(message);
            jsToastPOM.ClickCheckOnAddBehavior();
            jsToastPOM.ClickButtonShowToast();
            Thread.Sleep(2000);
            Assert.IsTrue(jsToastPOM.GetToastMessageText().Contains(message));
            jsToastPOM.ClickOnToast();
            Thread.Sleep(2000);
            Assert.AreEqual(alertText, jsToastPOM.GetAlertText());
            jsToastPOM.ClickOkOnAlert();
        }

        [TestMethod]
        //http://agilemanifesto.org/iso/es/manifesto.html
        public void TestMethod_EjercicioTypeToast()
        {
            JsToastrPOM jsToastPOM = new JsToastrPOM(this.driver);
            string message = "Hola Hugo";

            jsToastPOM.WriteOnMessage(message);
            jsToastPOM.ClickOnErrorType();
            jsToastPOM.ClickButtonShowToast();
            Thread.Sleep(2000);
            Assert.IsTrue(jsToastPOM.GetTypeToast("error") != null);
        }


        [TestCleanup]
        public void FinalizarDriver()
        {
            this.driver.Close();
        }
    }
}
