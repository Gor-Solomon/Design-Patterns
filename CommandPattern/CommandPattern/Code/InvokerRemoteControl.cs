using CommandPattern.Code.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Code
{
    delegate void UnExecuteMethod();
    class InvokerRemoteControl
    {
        const int capacity = 10;
        ICommand[] slotsOnCommand = new ICommand[capacity];
        ICommand[] slotsOffCommand = new ICommand[capacity];
        Stack<UnExecuteMethod> UnExecuteCommand = new Stack<UnExecuteMethod>();
        public InvokerRemoteControl()
        {
            for (int i = 0; i < capacity; i++)
            {
                slotsOnCommand[i] = new NoCommand();
                slotsOffCommand[i] = new NoCommand();
            }
        }
        public void SettCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            if (slot > capacity || slot < 1) { throw new Exception(); }

            slotsOnCommand[slot] = onCommand;
            slotsOffCommand[slot] = offCommand;
        }

        public void OnButtonPress(int slot)
        {
            if (slot > capacity || slot < 1) { throw new Exception(); }
            slotsOnCommand[slot].Execute();
            UnExecuteCommand.Push(slotsOnCommand[slot].UnExecute);
        }

        public void OffButtonPress(int slot)
        {
            if (slot > capacity || slot < 1) { throw new Exception(); }
            slotsOffCommand[slot].Execute();
            UnExecuteCommand.Push(slotsOffCommand[slot].UnExecute);
        }

        public void UnExecute()
        {
            if(UnExecuteCommand.Count > 0)
            {
                UnExecuteMethod um =  UnExecuteCommand.Pop();
                um.Invoke();
            }
        }
    }
}
