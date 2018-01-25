using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Interfaces;

namespace StrategyPattern.Robots
{

    class Robocop : Robot
    {
        public Robocop(IMove move, IAttack attack) : base(move, attack, "Robocop")
        {
        }
    }
}
