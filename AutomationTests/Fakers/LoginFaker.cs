using NaughtyStrings.Bogus;
using System;
using System.Collections.Generic;

namespace AutomationTests.Fakers
{
    public class LoginFaker
    {
        public static string GetNaughtyString()
        {
            IReadOnlyList<string> fakerList = TheNaughtyStrings.All;
            var naughty = fakerList[new Random().Next(0, fakerList.Count)];

            return naughty;
        }
    }
}
