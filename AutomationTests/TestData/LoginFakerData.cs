using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaughtyStrings;
using NaughtyStrings.Bogus;

namespace AutomationTests.TestData
{
    public class LoginFakerData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for(int i = 0; i < 10; i++)
            {
                yield return new object[] { GetNaughtyString() };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public string GetNaughtyString()
        {
            IReadOnlyList<string> fakerList = TheNaughtyStrings.All;

            return fakerList[new Random().Next(0, fakerList.Count)];
        }
    }
}
