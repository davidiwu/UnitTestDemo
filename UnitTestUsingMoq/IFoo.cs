using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestUsingMoq
{
    public interface IFoo
    {
        Bar Bar { get; set; }

        string Name { get; set; }

        int Value { get; set; }

        bool DoSomething(string value);

        bool DoSomething(int number, string value);

        string DoSomethingStringy(string value);

        bool TryParse(string value, out string outValue);

        bool Submit(ref Bar bar);

        int GetCount();

        bool Add(int value);
    }
}
