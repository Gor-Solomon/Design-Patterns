using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.Classes
{
    class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            Description = "DarkRoast";
        }

        public override double GetCost()
        {
            return base.GetCost() + 2.5;
        }
    }
}
