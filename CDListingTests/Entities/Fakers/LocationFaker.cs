using Bogus;
using CDListingTests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDListingTests.Entities.Fakers
{
    public static class LocationFaker
    {
        public static Faker<Location> Location()
        {
            return new Faker<Location>()
                .RuleFor(v => v.City, f => "Townsend")
                .RuleFor(v => v.State, f => "WI")
                .RuleFor(v => v.Zip, f => "54175");

        }
    }
}
