using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Interfaces;

namespace StrategyPattern.Behaviors
{
    class FunkyMove : IMove
    {
        public void Move()
        {
            Console.WriteLine("Moving funky way!");
        }
    }
}
