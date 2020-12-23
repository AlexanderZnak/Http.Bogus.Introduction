

using Bogus;
using CDListingTests.Models;

namespace CDListingTests
{
    public static class ListingFactory
    {
        public static ListingHttp listing;

        public static ListingHttp GenerateFakeListing()
        {
            listing = new ListingHttp()
            {
                Origin = new Location()
                {
                    City = "wafd", State

                }

            };
            return new ListingHttp();
        }

        private static Faker<ListingHttp> GenerateFakeData()
        {
            return new Faker<ListingHttp>()
                .RuleFor(x => x.TrailerType, f=> f.Random.ArrayElement())
        }
    }
}
