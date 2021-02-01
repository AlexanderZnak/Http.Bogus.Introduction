using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Xunit;

namespace AutomationTests.pages
{
    public class SearchPage : BasePage
    {
        private readonly By SaveSearchButton = By.CssSelector("[data-elementid='save-search-button']");

        public SearchPage(IWebDriver driver, ILogger<SearchPage> logger) : base(driver, logger) { }

        public override void OpenPage()
        {
            var url = _identitySettings.SearchUrl;
            Driver.Navigate().GoToUrl(url);

            Assert.True(IsPageOpened());
        }

        public override bool IsPageOpened()
        {
            bool isOpened;
            try
            {
                isOpened = Wait.Until(driver => Driver.FindElement(SaveSearchButton).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                isOpened = false;
            }

            return isOpened;
        }

    }
}
