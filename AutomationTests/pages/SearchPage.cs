using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using System;

namespace AutomationTests.pages
{
    public class SearchPage : BasePage
    {
        private const string SEARCH_DR = "https://searchdr.";
        private readonly By SaveSearchButton = By.CssSelector("[data-elementid='save-search-button']");

        public SearchPage(IWebDriver driver, ILogger<SearchPage> logger) : base(driver, logger) { }

        public override SearchPage OpenPage()
        {
            Driver.Navigate().GoToUrl(SEARCH_DR + URL);
            IsPageOpened();

            return this;
        }

        public override SearchPage IsPageOpened()
        {
            try
            {
                Wait.Until(driver => DriverFindElement(SaveSearchButton).Displayed == true);
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("Search page wasn't opened");
            }

            return this;
        }


    }
}
