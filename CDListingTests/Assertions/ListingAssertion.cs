using CDListingTests.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Collections.Generic;

namespace CDListingTests.Assertions
{
    public static class ListingAssertion
    {

        public static void ListingShouldBeCorrect(ListingHttp expectedListing, ListingHttp actualListing)
        {
            using (new AssertionScope())
            {
                actualListing.Should().BeEquivalentTo(expectedListing, options => options.Excluding(o => o.Vehicles), "Listing should be created correct");
            }
        }

        public static void VehicleShouldBeCorrect(ICollection<Vehicle> expectedVehicles, ICollection<Vehicle> actualVehicles)
        {
            actualVehicles.Should().BeEquivalentTo(expectedVehicles, options => options.Excluding(v => v.Id));
        }
    }
}
