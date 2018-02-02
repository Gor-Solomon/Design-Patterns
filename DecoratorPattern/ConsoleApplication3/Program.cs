using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ConsoleApplication3.Classes;

namespace ConsoleApplication3
{
    class Program
    {

        static void Main(string[] args)
        {
            Beverage darkRoast = new DarkRoast();
            darkRoast.AddCondiment<Mocha>();
            darkRoast.AddCondiment<Whipe>();
            Console.WriteLine("Cost is {0}", darkRoast.GetCost());
            darkRoast.RemoveCondiment<Whipe>();
            Console.WriteLine("Cost is {0}", darkRoast.GetCost());
            darkRoast.RemoveCondiment<Mocha>();
            Console.WriteLine("Cost is {0}", darkRoast.GetCost());
        }
    }
}
