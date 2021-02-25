using OpenQA.Selenium;

namespace SeleniumTests.PageObjectModel
{
    public class PrivatePage
    {
        // Instance variable.
        private IWebDriver _driver;

        // Constructor to call when creating a new instance of "PrivatePage".
        public PrivatePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Method to verify Menu Header.
        public bool isMenuHeaderPrivat()
        {
            var menuHeader = _driver.FindElement(By.CssSelector(".hero>nav:nth-child(1) > a:nth-child(1)"));
            return menuHeader.Text == "Privat";
        }
    }
}
