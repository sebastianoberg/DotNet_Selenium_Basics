using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.PageObjectModel
{
    public class StartPage
    {
        private readonly string collectorUrl = "https://www.collector.se/";
        private readonly WebDriverWait wait;

        private IWebDriver _driver;

        public StartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.LinkText, Using = "Privat")]
        private readonly IWebElement menuOptionPrivat;

        [FindsBy(How = How.CssSelector, Using = "button.cui-button:nth-child(3)")]
        private readonly IWebElement consentBtn;

        public void GoToStartPage()
        {
            _driver.Navigate().GoToUrl(collectorUrl);
        }

        public PrivatePage GoToPrivatPage()
        {
            menuOptionPrivat.Click();
            return new PrivatePage(_driver);
        }

        [System.Obsolete]
        public void ClickConsentBtnIfVisible()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(consentBtn)).Click();
        }
    }
}
