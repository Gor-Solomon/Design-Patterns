using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Code
{
    class InvokerRemoteControl
    {
        ICommand[] slotsOnCommand = new ICommand[10];
        ICommand[] slotsOffCommand = new ICommand[10];

        public InvokerRemoteControl()
        {
            for (int i = 0; i < slotsOnCommand.Length; i++)
            {
                slotsOnCommand[i] = null ;
                slotsOffCommand[i] = null;
            }
        }
        public void SettCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            if (slot > 10 || slot < 1) { throw new Exception(); }

            slotsOnCommand[slot] = onCommand;
            slotsOffCommand[slot] = offCommand;
        }

        public void OnButtonPress(int slot)
        {
            if (slot > 10 || slot < 1) { throw new Exception(); }
            slotsOnCommand[slot].Execute();
        }

        public void OffButtonPress(int slot)
        {
            if (slot > 10 || slot < 1) { throw new Exception(); }
            slotsOffCommand[slot].Execute();
        }
    }
}
