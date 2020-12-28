

using Bogus;
using CDListingTests.Entities.Fakers;

namespace CDListingTests
{
    public static class ListingFactory
    {

        public static Faker<ListingHttp> GenerateFakeListing() => ListingFaker.AllFields();


        //public static void WriteListingToFile()
        //{
        //    var listing = GenerateFakeListing().Generate();
        //    var jsonObj = JsonConvert.SerializeObject(listing);
        //    string pathToJsonFile = "..//..//..//listing.json";
        //    File.WriteAllText(pathToJsonFile, jsonObj);
        //}
    }
}
