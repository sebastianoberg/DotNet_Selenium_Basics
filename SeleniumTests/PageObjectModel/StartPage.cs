using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumTests.PageObjectModel
{
    public class StartPage
    {
        private readonly string collectorUrl = "https://www.collector.se/";
        private readonly IWebDriver _driver;

        // Constructor which is called when we create a new instance of StartPage. Ie. new StartPage(). Driver is the same as our test class so we passed that in: new StartPage(driver)..
        public StartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // After defining our constructor we define methods..
        public void GoToStartPage()
        {
            _driver.Navigate().GoToUrl(collectorUrl);
        }

        // More methods, or I guess we could call it functionality.. Note that this method returns a another page object.
        public PrivatePage GoToPrivatPage()
        {
            var privatPage = _driver.FindElement(By.LinkText("Privat"));
            privatPage.Click();
            return new PrivatePage(_driver);
        }

        // And even more functionality! 
        public void ClickConsentBtnIfVisible()
        {
            var consentButton = _driver.FindElement(By.CssSelector("button.cui-button:nth-child(3)"));
            var cookieModal = _driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[1]/div"));

            Assert.IsTrue(consentButton.Displayed);
            Assert.IsTrue(cookieModal.Displayed);

            if (consentButton != null)
            {
                consentButton.Click();
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
    }
}
