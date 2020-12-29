

using Bogus;
using CDListingTests.Entities.Fakers;

namespace CDListingTests
{
    public static class ListingFactory
    {

        public static Faker<ListingHttp> GenerateFakeListing() => ListingFaker.AllFields();
    }
}
