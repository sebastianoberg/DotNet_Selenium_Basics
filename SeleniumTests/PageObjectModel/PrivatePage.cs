using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTests.PageObjectModel
{
    public class PrivatePage
    {
        private IWebDriver _driver;

        public PrivatePage(IWebDriver driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = ".hero>nav:nth-child(1) > a:nth-child(1)")]
        private readonly IWebElement menuHeader;

        public bool isMenuHeaderPrivat()
        {
            return menuHeader.Text == "Privat";
        }
    }
}
