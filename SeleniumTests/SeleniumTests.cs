using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.PageObjectModel;

namespace SeleniumTests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly string collectorUrl = "https://www.collector.se/";

        [TestMethod]
        public void BasicSeleniumFlow()
        {
            IWebElement okConsentButton;
            IWebElement privateNavigationOption;
            IWebElement menuHeader;

            // You can find Chrome Driver here: https://sites.google.com/a/chromium.org/chromedriver/downloads
            // Pass "." as argument when creating the ChromeDriver. By doing that we will look for chromedriver.exe in the current folder.
            using (var driver = new ChromeDriver("."))
            {
                // This is a basic selenium flow, navigating the webapage of Collector Bank.
                // The flow is straight forward, no POM pattern, so the test is hard to follow. Even harder to maintain as it might grow.
                driver.Navigate().GoToUrl(collectorUrl);

                okConsentButton = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[1]/div/div/button"));

                if (okConsentButton.Displayed == true)
                {
                    okConsentButton?.Click();
                }

                privateNavigationOption = driver.FindElementByLinkText("Privat");
                privateNavigationOption.Click();

                menuHeader = driver.FindElement(By.CssSelector(".hero>nav:nth-child(1) > a:nth-child(1)"));
                Assert.IsTrue(menuHeader.Text == "Privat");
            }
        }

        [TestMethod]
        public void SeleniumFlowUsingPageObjectModel()
        {
            // Using our PageObjects (PrivatePage and StartPage) we can create tests that are easy to extend, maintain and read.
            // Way easier to read than the test above? Both tests do the same. 
            using (var driver = new ChromeDriver("."))
            {
                // create instance of page object StartPage
                StartPage home = new StartPage(driver);
                // Navigate StartPage using our defined methods..
                home.GoToStartPage();
                // Keep on navigating...
                home.ClickConsentBtnIfVisible();

                // Create instance of PrivatePage..
                PrivatePage privat = home.GoToPrivatPage();
                // And navigate using our methods.
                Assert.IsTrue(privat.isMenuHeaderPrivat());
            }
        }
    }
}
