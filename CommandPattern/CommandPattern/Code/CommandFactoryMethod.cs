using CommandPattern.Code.Commands;
using CommandPattern.Code.Recivers;
using CommandPattern.Code.Recivers.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommandPattern.Code
{
    enum CommandsType {
        Light,
        Garage
    }
    class CommandFactoryMethod
    {
        Window win;

        public CommandFactoryMethod(Window window)
        {
            win = window;
        }
        public void GetCommand(CommandsType commandType,out ICommand onCommand, out ICommand offCommand)
        {
            switch (commandType)
            {
                case CommandsType.Light:
                    Light light = new Light(win);
                    onCommand = new LightOnCommand(light);
                    offCommand = new LightOffCommand(light);
                    break;
                case CommandsType.Garage:
                    Garage garage = new Garage(win);
                    onCommand = new GarageDoorOpenCommand(garage);
                    offCommand = new GarageDoorCloseCommand(garage);
                    break;
                default:
                    onCommand = default(ICommand);
                    offCommand = default(ICommand);
                    break;
            }
        }
    }
}
