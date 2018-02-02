using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Interfaces;

namespace ConsoleApplication3.Classes
{
    abstract class CondimentDecorator : ICost
    {
        public CondimentDecorator()
        {
            Description = "Condiment";
        }

        public string Description { get; set; }

        public virtual double GetCost()
        {
            return 1;
        }
    }
}
