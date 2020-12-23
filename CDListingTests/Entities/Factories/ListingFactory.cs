

using Bogus;
using CDListingTests.Entities.Fakers;
using Newtonsoft.Json;
using System;
using System.IO;

namespace CDListingTests
{
    public static class ListingFactory
    {

        public static Faker<ListingHttp> GenerateFakeListing()
        {
            return ListingFaker.AllFields();
        }

        public static void WriteListingToFile()
        {
            var listing = GenerateFakeListing().Generate();
            var jsonObj = JsonConvert.SerializeObject(listing);
            string pathToJsonFile = "..//..//..//listing.json";
            File.WriteAllText(pathToJsonFile, jsonObj);
        }
    }
}
