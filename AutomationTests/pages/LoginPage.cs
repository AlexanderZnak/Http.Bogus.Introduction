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
            Driver.Navigate().GoToUrl(url + "/Account/Login?ReturnUrl=%2Fconnect%2Fauthorize%2Fcallback%3Fclient_id%3Dcentral_dispatch_web_client%26redirect_uri%3Dhttps%253A%252F%252Fsearchdr.centraldispatch.com%252Foidc-callback%26response_type%3Dtoken%2520id_token%26scope%3Dopenid%2520listings_search%2520listings_search_web_bff%26state%3Dc2135025226d484591d71664fc9f7cfc%26nonce%3D2b8d77e13d4c48abbfb1552b96e546df");

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
