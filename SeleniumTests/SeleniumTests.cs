using System;
using System.Collections.Generic;
using System.Linq;
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
            IWebElement siteHeader;
            IWebElement privateNavigationOption;

            IEnumerable<string> menuOptions = new List<string>() { "Privat", "Företag", "Om Collector" };
            IEnumerable<string> actualMenuOptions = new List<string>();


            using (var driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(collectorUrl);

                okConsentButton = driver.FindElementByCssSelector("button.cui-button:nth-child(3)");

                if (okConsentButton.Displayed == true)
                {
                    okConsentButton?.Click();
                }

                siteHeader = driver.FindElement(By.Id("logo"));
                privateNavigationOption = driver.FindElementByLinkText("Privat");

                IReadOnlyCollection<IWebElement> allElements = driver.FindElements(By.ClassName("menu"));

                foreach (IWebElement element in allElements)
                {
                    actualMenuOptions.Append(element.Text.ToString());

                    System.Diagnostics.Debug.WriteLine(element.Text);
                }

                privateNavigationOption.Click();
            }
        }

        [TestMethod]
        public void SeleniumFlowUsingPageObjectModel()
        {

            using (var driver = new ChromeDriver("."))
            {
                StartPage home = new StartPage(driver);
                home.GoToStartPage();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                home.ClickConsentBtnIfVisible();
                PrivatePage privat = home.GoToPrivatPage();
                Assert.IsTrue(privat.isMenuHeaderPrivat());
            }
        }

        //private static bool ListsContainAMatchingValue(IEnumerable<string> listA, IEnumerable<string> listB)
        //{
        //    return listA.Any(x => listB.Contains(x));
        //}
    }
}
