using Bogus;
using CDListingTests.Models;
using CDListingTests.Models.Enums;
using System;

namespace CDListingTests.Entities.Fakers
{
    public static class VehicleFaker
    {
        public static Faker<Vehicle> AllFields()
        {
            return new Faker<Vehicle>()
                .RuleFor(v => v.Make, f => f.Vehicle.Manufacturer().ToLower())
                .RuleFor(v => v.Model, f => f.Vehicle.Model().ToLower())
                .RuleFor(v => v.Year, f => f.Date.Past(f.Random.Int(1, 10), DateTime.Now).Year)
                .RuleFor(v => v.Id, f => "1")
                .RuleFor(v => v.Qty, f => 1)
                .RuleFor(v => v.WideLoad, f => f.Random.Bool())
                .RuleFor(v => v.VehicleType, f => f.PickRandom<VehicleType>());
        }
    }
}
