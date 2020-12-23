using Bogus;
using CDListingTests.Models;
using CDListingTests.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDListingTests.Entities.Fakers
{
    public static class CodFaker
    {
        public static Faker<Cod> Cod()
        {
            return new Faker<Cod>()
                .RuleFor(v => v.Amount, f => f.Random.Decimal(1M, 10000M))
                .RuleFor(v => v.PaymentLocation, f => f.PickRandom<CodPaymentLocation>())
                .RuleFor(v => v.PaymentMethod, f => f.PickRandom<CodPaymentMethod>());
        }
    }
}
