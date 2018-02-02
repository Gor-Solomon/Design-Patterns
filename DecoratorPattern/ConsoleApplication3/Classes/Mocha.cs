using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.Classes
{
    class Mocha : CondimentDecorator
    {
        public Mocha()
        {
            base.Description = "Mocha";
        }

        public override double GetCost()
        {
            return 1.25;
        }
    }
}
