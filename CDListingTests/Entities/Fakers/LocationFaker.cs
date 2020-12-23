using Bogus;
using CDListingTests.Models;

namespace CDListingTests.Entities.Fakers
{
    public static class LocationFaker
    {
        public static Faker<Location> CreateOrigin()
        {
            return new Faker<Location>()
                .RuleFor(v => v.City, f => "Townsend")
                .RuleFor(v => v.State, f => "WI")
                .RuleFor(v => v.Zip, f => "54175");
        }

        public static Faker<Location> CreateDestination()
        {
            return new Faker<Location>()
                .RuleFor(v => v.City, f => "Beverly Hills")
                .RuleFor(v => v.State, f => "CA")
                .RuleFor(v => v.Zip, f => "90210");
        }
    }
}
