using Xunit;
using Xunit.Abstractions;

namespace CDListingTests
{
    public class ListingTests
    {
        private readonly ITestOutputHelper OutputHelper;
        private readonly ListingService ListingService;
        public ListingTests(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            ListingService = new ListingService(OutputHelper.ToLogger<ListingService>());
        }

        [Fact]
        public async void ListingShouldBeCreated()
        {
            //Arrange
            var token = await ListingService.GetToken();

            //Act
            var response = await ListingService.CreateListing(token);

            // Assert
            Assert.Equal(201, (int)response.StatusCode);

        }

        [Fact]
        [Trait("Category", "Api")]
        public async void ListingShouldBeRead()
        {
            // Arrange
            var token = await ListingService.GetToken();

            var createListing = await ListingService.CreateListing(token);

            var id = ListingService.ExtractIdFromHeaders(createListing);

            // Act
            var response = await ListingService.GetListing(id, token);

            // Assert
            Assert.Equal(200, (int)response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Api")]
        public async void ListingShouldBeUpdated()
        {
            // Arrange
            var token = await ListingService.GetToken();

            var createListing = await ListingService.CreateListing(token);

            var id = ListingService.ExtractIdFromHeaders(createListing);

            // Act
            var response = await ListingService.UpdateListing(id, token);

            // Assert
            Assert.Equal(204, (int)response.StatusCode);

        }

        [Fact]
        [Trait("Category", "Api")]
        public async void ListingShouldBeDeleted()
        {
            // Arrange
            var token = await ListingService.GetToken();

            var createListing = await ListingService.CreateListing(token);

            var id = ListingService.ExtractIdFromHeaders(createListing);

            // Act
            var response = await ListingService.DeleteListing(id, token);

            // Assert
            Assert.Equal(204, (int)response.StatusCode);

        }

    }
}
