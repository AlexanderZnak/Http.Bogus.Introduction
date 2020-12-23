using Bogus;
using CDListingTests.Models.Enums;
using System;

namespace CDListingTests.Entities.Fakers
{
    public static class ListingFaker
    {
        public static Faker<ListingHttp> AllFields()
        {
            var cod = CodFaker.Cod().Generate();
            var vehicles = VehicleFaker.AllFields().Generate(2);
            var price = PriceFaker.Price(cod).Generate();

            return new Faker<ListingHttp>()
                .RuleFor(a => a.Origin, LocationFaker.CreateOrigin().Generate())
                .RuleFor(a => a.Destination, LocationFaker.CreateDestination().Generate())
                .RuleFor(a => a.Vehicles, vehicles)
                .RuleFor(a => a.TrailerType, l => l.PickRandom<TrailerType>())
                .RuleFor(a => a.PartnerReferenceId, "multi-car")
                .RuleFor(a => a.Price, price)
                .RuleFor(a => a.HasInOpVehicle, l => l.Random.Bool())
                .RuleFor(a => a.AvailableDate, l => DateTime.Now.AddYears(l.Random.Int(1, 4)).ToString("yyyy-MM-dd"))
                .RuleFor(a => a.DesiredDeliveryDate, l => DateTime.Now.AddYears(l.Random.Int(4, 5)).ToString("yyyy-MM-dd"));
        }
    }
}
