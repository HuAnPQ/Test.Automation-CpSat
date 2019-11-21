using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Automation.Pages
{
    public class InterBankPeru
    {
        [FindsBy(How = How.ClassName, Using = "lh-cta-sorpresas__img__gift")]
        public IWebElement CrearCuenta { get; set; }

        [FindsBy(How= How.Id, Using = "cs-txtDocumentModal")]
        public IWebElement NumeroDNI { get; set; }


        [FindsBy(How = How.Id, Using = "cs-txtTelfModal")]
        public IWebElement Celular { get; set; }

        [FindsBy(How=How.Id,Using = "cs-txtEmailModal")]
        public IWebElement Email { get; set; }

        [FindsBy(How=How.Id,Using = "lq-sb__button--submit")]
        public IWebElement ButtonEnviar { get; set; }

    }
}
