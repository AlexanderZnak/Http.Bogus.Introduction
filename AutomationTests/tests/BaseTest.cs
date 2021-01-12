using AutomationTests.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit.Abstractions;

namespace AutomationTests.tests
{
    public class BaseTest : IDisposable
    {
        public const string USERNAME = "srctest2";
        public const string PASSWORD = "TeSt!2#4";
        private readonly IWebDriver Driver;
        private readonly ITestOutputHelper OutputHelper;
        protected readonly LoginPage LoginPage;
        protected readonly SearchPage SearchPage;
        public BaseTest(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage = new LoginPage(Driver, OutputHelper.ToLogger<LoginPage>());
            SearchPage = new SearchPage(Driver, OutputHelper.ToLogger<SearchPage>());

        }
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
