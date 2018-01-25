using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Interfaces;

namespace StrategyPattern.Robots
{
    class Grendaizer : Robot
    {
        public Grendaizer(IMove move, IAttack attack) : base(move, attack, "Grendaizer")
        {
        }
    }
}
