using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Automation.PageModels
{
    public class JsAlertPaginaWeb
    {
        private IWebDriver _driver;
        private static readonly string ALERT_XPATH = "/html/body/div[2]/div/div/ul/li[1]/button";
        private static readonly string CONFIRM_XPATH = "/html/body/div[2]/div/div/ul/li[2]/button";
        private static readonly string PROMPT_XPATH = "/html/body/div[2]/div/div/ul/li[3]/button";
        private static readonly string RESULT_ID = "result";

        public JsAlertPaginaWeb(IWebDriver driver)
        {
            this._driver = driver;
            this._driver.Navigate().GoToUrl(@"https://the-internet.herokuapp.com/javascript_alerts");
        }

        public string GetResultText()
        {
            return this._driver.FindElement(By.Id(RESULT_ID)).Text;
        }

        public string GetAlertText()
        {
            return this._driver.SwitchTo().Alert().Text;
        }

        public void WriteOnAlert(string message)
        {
            this._driver.SwitchTo().Alert().SendKeys(message);
        }

        public void ClickOkOnAlert()
        {
            this._driver.SwitchTo().Alert().Accept();
        }
        public void ClickCancelOnAlert()
        {
            this._driver.SwitchTo().Alert().Dismiss();
        }

        public void ClickConfirmButton()
        {
            this.clickOnXpath(CONFIRM_XPATH);
        }

        public void ClickAlertButton()
        {
            this.clickOnXpath(ALERT_XPATH);
        }

        public void ClickPromptButton()
        {
            this.clickOnXpath(PROMPT_XPATH);
        }

        private void clickOnXpath(string xpath)
        {
            this._driver.FindElement(By.XPath(xpath)).Click();
        }
    }
}
