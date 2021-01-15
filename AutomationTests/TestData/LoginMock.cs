using AutomationTests.Fakers;
using System.Collections;
using System.Collections.Generic;

namespace AutomationTests.TestData
{
    public class LoginMock : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i < 2; i++)
            {
                yield return new object[] { LoginFaker.GetNaughtyString() };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
