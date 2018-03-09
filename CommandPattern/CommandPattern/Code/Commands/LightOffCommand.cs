using CommandPattern.Code.Recivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Code.Commands
{
    class LightOffCommand : ICommand
    {
        Light light;
        public LightOffCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            if (this.light != null)
            {
                this.light.Off();
            }
        }
    }
}
