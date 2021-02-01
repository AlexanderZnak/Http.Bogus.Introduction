using AutomationTests.Configuration;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationTests.pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;
        protected readonly ILogger Logger;
        protected readonly IdentitySettings _identitySettings = ConfigManager.GetInstance().IdentitySettings;

        public BasePage(IWebDriver driver, ILogger<BasePage> logger)
        {
            Logger = logger;
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public abstract void OpenPage();

        public abstract bool IsPageOpened();

        public void Click(By locator)
        {
            Logger.LogInformation($"Click element by locator : {locator}");
            IWebElement element = Driver.FindElement(locator);
            try
            {
                Wait.Until(d => element.Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element is not displayed to click");
            }

            element.Click();
        }

    }
}
