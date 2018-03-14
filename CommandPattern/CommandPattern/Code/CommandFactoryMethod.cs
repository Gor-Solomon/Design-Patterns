using CommandPattern.Code.Commands;
using CommandPattern.Code.Recivers;
using CommandPattern.Code.Recivers.Garage;
using CommandPattern.Code.Recivers.Light;
using CommandPattern.Code.Recivers.Stereo;
using System.Windows;

namespace CommandPattern.Code
{
    enum CommandsType {
        Light,
        Garage,
        Stereo,
        MacroCommand
    }
    class CommandFactoryMethod
    {
        Window win;

        public CommandFactoryMethod(Window window)
        {
            win = window;
        }
        public IControlebel GetCommand(CommandsType commandType,out ICommand onCommand, out ICommand offCommand)
        {
            IControlebel controlebel;

            switch (commandType)
            {
                case CommandsType.Light:
                    controlebel = new Light(win);
                    onCommand = new LightOnCommand(controlebel);
                    offCommand = new LightOffCommand(controlebel);
                    break;
                case CommandsType.Garage:
                    controlebel = new Garage(win);
                    onCommand = new GarageDoorOpenCommand(controlebel);
                    offCommand = new GarageDoorCloseCommand(controlebel);
                    break;
                case CommandsType.Stereo:
                    controlebel = new Stereo(win);
                    onCommand = new StereoOnWithCDCommand(controlebel);
                    offCommand = new StereoOffCommand(controlebel);
                    break;
                case CommandsType.MacroCommand:
                    controlebel = default(IControlebel);
                    onCommand = new MacroCommand();
                    offCommand = new MacroCommand();
                    break;
                default:
                    controlebel = default(IControlebel);
                    onCommand = default(ICommand);
                    offCommand = default(ICommand);
                    break;
            }

            return controlebel;
        }
    }
}
