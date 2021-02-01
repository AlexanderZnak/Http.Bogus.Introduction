using NaughtyStrings.Bogus;
using System;

namespace AutomationTests.Fakers
{
    public class LoginFaker
    {
        public static string GetNaughtyString()
        {
            var fakerList = TheNaughtyStrings.All;
            var naughtyData = fakerList[new Random().Next(0, fakerList.Count)];

            return naughtyData;
        }
    }
}
