using CommandPattern.Code.Recivers.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Code.Commands
{
    class GarageDoorOpenCommand : ICommand
    {
        Garage garage;

        public GarageDoorOpenCommand(Garage garage)
        {
            this.garage = garage;
        }
   
        public void Execute()
        {
            if (garage != null)
            {
                garage.Up();
            }
        }
    }
}
