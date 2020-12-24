using Bogus;
using CDListingTests.Models;
using CountryData;

namespace CDListingTests.Entities.Fakers
{
    public static class LocationFaker
    {
        public static Faker<Location> CreateOrigin()
        {
            Loader(out IState state, out string placeName, out string postCode);
            return new Faker<Location>()
            .RuleFor(v => v.City, f => placeName)
            .RuleFor(v => v.State, f => state.Code)
            .RuleFor(v => v.Zip, f => postCode);

        }

        public static Faker<Location> CreateDestination()
        {
            Loader(out IState state, out string placeName, out string postCode);
            return new Faker<Location>()
                .RuleFor(v => v.City, f => placeName)
                .RuleFor(v => v.State, f => state.Code)
                .RuleFor(v => v.Zip, f => postCode);
        }

        private static void Loader(out IState state, out string placeName, out string postCode)
        {
            var usaData = CountryLoader.LoadUnitedStatesLocationData();
            var states = usaData.States;
            state = states[new Randomizer().Int(1, states.Count - 1)];
            var provinces = state.Provinces;
            var province = provinces[new Randomizer().Int(0, provinces.Count - 1)];
            var communities = province.Communities;
            var community = communities[new Randomizer().Int(0, communities.Count - 1)];
            var places = community.Places;
            var place = places[new Randomizer().Int(0, places.Count - 1)];
            placeName = place.Name;
            postCode = place.PostCode;
        }
    }
}
