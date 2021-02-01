using AutomationTests.Configuration;
using AutomationTests.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit.Abstractions;

namespace AutomationTests.tests
{
    public class BaseTest : IDisposable
    {
        private readonly IWebDriver Driver;
        private readonly ITestOutputHelper OutputHelper;
        protected readonly LoginPage LoginPage;
        protected readonly SearchPage SearchPage;
        protected readonly IdentitySettings _identitySettings = ConfigManager.GetInstance().IdentitySettings;
        public BaseTest(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            LoginPage = new LoginPage(Driver, OutputHelper.ToLogger<LoginPage>());
            SearchPage = new SearchPage(Driver, OutputHelper.ToLogger<SearchPage>());

        }
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
