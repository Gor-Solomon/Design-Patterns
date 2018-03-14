using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Code.Commands
{
    class MacroCommand : ICommand
    {
        List<ICommand> commands;
        public MacroCommand()
        {
            commands = new List<ICommand>();
        }
        public void Execute()
        {
            foreach (var item in commands)
            {
                item.Execute();
            }
        }

        public void UnExecute()
        {
            foreach (var item in commands)
            {
                item.UnExecute();
            }
        }

        public void SetCommand(ICommand command)
        {
            commands.Add(command);
        }
    }
}
