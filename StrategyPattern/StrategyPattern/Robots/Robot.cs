using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Interfaces;

namespace StrategyPattern.Robots
{
    class Robot
    {
        protected string Name;
        IMove moveAlgorithem;
        IAttack attackAlgorithem;

        public IMove MoveAlgorithem { get { return moveAlgorithem; } set { moveAlgorithem = value ?? moveAlgorithem; } }
        public IAttack AttackAlgorithem { get { return attackAlgorithem; } set { attackAlgorithem = value ?? attackAlgorithem; } }

        public Robot(IMove move, IAttack attack,string name)
        {
            this.MoveAlgorithem = move;
            this.AttackAlgorithem = attack;
            this.Name = name;
        }

        public void DoMove()
        {
            if(this.moveAlgorithem != null)
            {
                this.moveAlgorithem.Move();
            }
            
        }

        public void DoAttack()
        {
            if (this.attackAlgorithem != null)
            {
                this.attackAlgorithem.Attack();
            }
            
        }

        public void Show()
        {
            Console.WriteLine("This is {0} robot", this.Name);
        }

    }
}
