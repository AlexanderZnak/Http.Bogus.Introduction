using Bogus;
using CDListingTests.Models;
using CDListingTests.Models.Enums;

namespace CDListingTests.Entities.Fakers
{
    public static class CodFaker
    {
        public static Faker<Cod> Cod()
        {
            return new Faker<Cod>()
                .RuleFor(v => v.Amount, f => f.Random.Number(1, 10000))
                .RuleFor(v => v.PaymentLocation, f => f.PickRandom<CodPaymentLocation>())
                .RuleFor(v => v.PaymentMethod, f => f.PickRandom<CodPaymentMethod>());
        }
    }
}
