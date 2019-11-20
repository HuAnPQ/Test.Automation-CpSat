using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Automation.PageModels
{
    public class JsToastrPOM
    {
        private IWebDriver _driver;
        private string title;
        private static readonly string TITLE_ID = "title";
        private static readonly string MESSAGE_ID = "message";
        private static readonly string CHECK_CLOSEBUTTON_ID = "closeButton";
        private static readonly string CHECK_ADDBEHAVIOR_ID = "addBehaviorOnToastClick";
        private static readonly string CHECK_DEBUG_ID = "debugInfo";
        private static readonly string CHECK_PROGRESSBAR_ID = "progressBar";
        private static readonly string CHECK_PREVENTDUPLICATES_ID = "preventDuplicates";
        private static readonly string CHECK_ADDCLEAR_ID = "addClear";
        private static readonly string CHECK_NEWESTONTOP_ID = "newestOnTop";
        private static readonly string BUTTON_SHOWTOAST_ID = "showtoast";
        private static readonly string BUTTON_CLEARTOASTS_ID = "cleartoasts";
        private static readonly string BUTTON_CLEARLASTTOAST_ID = "clearlasttoast";
        private static readonly string TYPEGROUP_ID = "toastTypeGroup";
        private static readonly string SUCCESSTYPE_XPATH = "div/label[2]/input";
        private static readonly string INFOTYPE_XPATH = "div/label[3]/input";
        private static readonly string WARNINGTYPE_XPATH = "div/label[4]/input";
        private static readonly string ERRORTYPE_XPATH = "div/label[5]/input";

        private static readonly string TOASTCONTAINER_ID = "toast-container";
        private static readonly string TITLE_CSSSELECTOR = ".toast-title";
        private static readonly string MESSAGE_CSSSELECTOR = ".toast-message";
        private static readonly string CLOSE_CSSSELECTOR = ".toast-close-button";


        public JsToastrPOM(IWebDriver driver)
        {
            this._driver = driver;
            this._driver.Navigate().GoToUrl(@"https://codeseven.github.io/toastr/demo.html");
        }

        public string GetToastMessageText()
        {
            return this._driver.FindElement(By.Id(TOASTCONTAINER_ID))
                .FindElement(By.CssSelector(MESSAGE_CSSSELECTOR)).Text;
        }

        public string GetToastTitleText()
        {
            return this._driver.FindElement(By.Id(TOASTCONTAINER_ID))
                .FindElement(By.CssSelector(TITLE_CSSSELECTOR)).Text;
        }

        public object GetButtonToastClose()
        {
            return this._driver.FindElement(By.Id(TOASTCONTAINER_ID))
                .FindElement(By.CssSelector(CLOSE_CSSSELECTOR));
        }

        public object GetTypeToast(string type)
        {
            return this._driver.FindElement(By.Id(TOASTCONTAINER_ID))
                .FindElement(By.CssSelector(".toast-" + type));
        }

        public string GetAlertText()
        {
            return this._driver.SwitchTo().Alert().Text;
        }

        public void WriteOnTitle(string title)
        {
            this._driver.FindElement(By.Id(TITLE_ID)).SendKeys(title);
        }

        public void WriteOnMessage(string message)
        {
            this._driver.FindElement(By.Id(MESSAGE_ID)).SendKeys(message);
        }

        private void ClickOnId(string id)
        {
            this._driver.FindElement(By.Id(id)).Click();
        }

        public void ClickCheckOnCloseButton()
        {
            this.ClickOnId(CHECK_CLOSEBUTTON_ID);
        }

        public void ClickCheckOnAddBehavior()
        {
            this.ClickOnId(CHECK_ADDBEHAVIOR_ID);
        }
        public void ClickCheckOnDebug()
        {
            this.ClickOnId(CHECK_DEBUG_ID);
        }
        public void ClickCheckOnProgressBar()
        {
            this.ClickOnId(CHECK_PROGRESSBAR_ID);
        }

        public void ClickCheckOnPreventDuplicates()
        {
            this.ClickOnId(CHECK_PREVENTDUPLICATES_ID);
        }
        public void ClickCheckOnAddClear()
        {
            this.ClickOnId(CHECK_ADDCLEAR_ID);
        }
        public void ClickCheckOnNewstOnTop()
        {
            this.ClickOnId(CHECK_NEWESTONTOP_ID);
        }

        public void ClickButtonShowToast()
        {
            this.ClickOnId(BUTTON_SHOWTOAST_ID);
        }

        public void ClickButtonClearToasts()
        {
            this.ClickOnId(BUTTON_CLEARTOASTS_ID);
        }

        public void ClickButtonClearLastToast()
        {
            this.ClickOnId(BUTTON_CLEARLASTTOAST_ID);
        }

        public void ClickOnToast()
        {
            this.ClickOnId(TOASTCONTAINER_ID);
        }

        public void ClickOkOnAlert()
        {
            this._driver.SwitchTo().Alert().Accept();
        }

        public void ClickOnTypeByXpath(string xpath)
        {
            this._driver.FindElement(By.Id(TYPEGROUP_ID))
                .FindElement(By.XPath(xpath)).Click();
        }

        public void ClickOnSuccessType()
        {
            this.ClickOnTypeByXpath(SUCCESSTYPE_XPATH);
        }

        public void ClickOnInfoType()
        {
            this.ClickOnTypeByXpath(INFOTYPE_XPATH);
        }

        public void ClickOnWarningType()
        {
            this.ClickOnTypeByXpath(WARNINGTYPE_XPATH);
        }

        public void ClickOnErrorType()
        {
            this.ClickOnTypeByXpath(ERRORTYPE_XPATH);
        }

    }
}
