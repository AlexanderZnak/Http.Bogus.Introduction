using AutomationTests.TestData;
using Xunit;
using Xunit.Abstractions;

namespace AutomationTests.tests
{
    public class LoginTest : BaseTest
    {
        public LoginTest(ITestOutputHelper outputHelper) : base(outputHelper) { }

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

        }

        [Theory]
        [ClassData(typeof(LoginMock))]
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
            var actualErrorMessage = LoginPage.GetErrorText();
            var expectedErrorMessage = "Username and Password did not match.";

            Assert.Equal(expectedErrorMessage, actualErrorMessage);

        }

        [Theory]
        [ClassData(typeof(LoginMock))]
        public void ErrorShouldBeAppearedWithInvalidUsername(string username)
        {
            // Arrange
            LoginPage
                .OpenPage();

            // Act
            LoginPage
                .FillInFieldsUsernamePassword(username, PASSWORD)
                .ClickSignIn();

            // Assert
            var actualErrorMessage = LoginPage.GetErrorText();
            var expectedErrorMessage = "Invalid username";

            Assert.Equal(expectedErrorMessage, actualErrorMessage);

        }

    }
}
