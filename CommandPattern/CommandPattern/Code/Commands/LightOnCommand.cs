using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Code.Recivers;

namespace CommandPattern.Code.Commands
{
    class LightOnCommand : ICommand
    {
        Light light;
        public LightOnCommand(Light light )
        {
            this.light = light;
        }
        public void Execute()
        {
            if (this.light != null)
            {
                this.light.On();
            }
        }
    }
}
