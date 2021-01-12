using AutomationTests.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationTests.tests
{
    public class BaseTest : IDisposable
    {
        public const string USERNAME = "t3amsp1";
        public const string PASSWORD = "TeSt!2#4";
        private readonly IWebDriver Driver;
        protected readonly LoginPage LoginPage;
        protected readonly SearchPage SearchPage;
        public BaseTest()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage = new LoginPage(Driver);
            SearchPage = new SearchPage(Driver);

        }
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
