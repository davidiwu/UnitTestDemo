using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestUsingMoq
{
    public class Bar
    {
        public virtual Baz Baz { get; set; }

        public virtual bool Submit()
        {
            return false;
        }
    }
}
