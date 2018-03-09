using CommandPattern.Code.Recivers.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Code.Commands
{
    class GarageDoorCloseCommand : ICommand
    {
        Garage garage;

        public GarageDoorCloseCommand(Garage garage)
        {
            this.garage = garage;
        }

        public void Execute()
        {
            if (garage != null)
            {
                garage.Down();
            }
        }
    }
}
