using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Robots;
using StrategyPattern.Behaviors;


namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot R1 = new Robocop(new FunkyMove(), new laserAttack());

            R1.Show();
            R1.DoMove();
            R1.DoAttack();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            Robot R2 = new Grendaizer(new CurrvyMove(), new RocketAttack());

            R2.Show();
            R2.DoMove();
            R2.DoAttack();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            Console.WriteLine("now changing behaviors!");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            R1.MoveAlgorithem = new CurrvyMove();
            R1.AttackAlgorithem = new RocketAttack();

            R1.Show();
            R1.DoMove();
            R1.DoAttack();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            R2.MoveAlgorithem = new FunkyMove();
            R2.AttackAlgorithem = new laserAttack();

            R2.Show();
            R2.DoMove();
            R2.DoAttack();

        }
    }
}
