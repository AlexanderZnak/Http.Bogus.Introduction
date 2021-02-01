using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Xunit;

namespace AutomationTests.pages
{
    public class LoginPage : BasePage
    {
        private readonly By UsernameInput = By.Id("Username");
        private readonly By PasswordInput = By.Id("password");
        private readonly By LoginButton = By.Id("loginButton");
        private readonly By AllertError = By.CssSelector(".danger");
        public LoginPage(IWebDriver driver, ILogger<LoginPage> logger) : base(driver, logger) { }

        public override void OpenPage()
        {
            var url = _identitySettings.LoginUrl;
            Driver.Navigate().GoToUrl(url);

            Assert.True(IsPageOpened());
        }

        public override bool IsPageOpened()
        {
            bool isOpened;
            try
            {
                isOpened = Wait.Until(driver => Driver.FindElement(LoginButton).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                isOpened = false;
            }

            return isOpened;
        }

        public LoginPage FillInFieldsUsernamePassword(string username, string password)
        {
            Driver.FindElement(UsernameInput).SendKeys(username);
            Driver.FindElement(PasswordInput).SendKeys(password);

            return this;
        }

        public LoginPage ClickSignIn()
        {
            Click(LoginButton);

            return this;
        }

        public string GetErrorText()
        {
            var errorMessage = Driver.FindElement(AllertError).Text;
            Logger.LogInformation($"Error message is : {errorMessage}");

            return errorMessage;
        }

    }
}
