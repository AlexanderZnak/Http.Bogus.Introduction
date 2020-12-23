using Bogus;
using CDListingTests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDListingTests.Entities.Fakers
{
    public static class PriceFaker
    {
        public static Faker<Price> Price(Cod cod)
        {
            return new Faker<Price>()
                .RuleFor(v => v.Cod, f => cod)
                .RuleFor(v => v.Total, f => cod.Amount);
        }
    }
}
