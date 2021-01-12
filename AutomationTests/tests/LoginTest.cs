using AutomationTests.TestData;
using System.Threading;
using Xunit;

namespace AutomationTests.tests
{
    public class LoginTest : BaseTest
    {

        [Fact]
        public void SearchPageShouldBeOpenedAfterLogIn()
        {
            // Arrange
            LoginPage
                .OpenPage();

            // Act
            LoginPage
                .FillInFieldsUsernamePassword(USERNAME, PASSWORD)
                .ClickSignIn();

            // Assert
            SearchPage.IsPageOpened();
            Thread.Sleep(4000);
        }

        [Theory]
        [ClassData(typeof(LoginFakerData))]
        public void ErrorShouldBeAppearedWithInvalidPassword(string password)
        {
            // Arrange
            LoginPage
                .OpenPage();

            // Act
            LoginPage
                .FillInFieldsUsernamePassword(USERNAME, password)
                .ClickSignIn();

            // Assert
            SearchPage.IsPageOpened();
            Thread.Sleep(4000);
        }

    }
}
