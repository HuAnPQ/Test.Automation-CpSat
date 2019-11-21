using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Automation.Pages
{
    public class AddRemoveElements
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/button")]
        public IWebElement AddElementButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "added-manually")]
        public IList<IWebElement> NewButtons { get; set; }

    }
}
