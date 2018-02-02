using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.Classes
{
    class Whipe : CondimentDecorator
    {
        public Whipe()
        {
            base.Description = "Whipe";
        }

        public override double GetCost()
        {
            return 0.25;
        }
    }
}
