using CommandPattern.Code.Recivers;
using CommandPattern.Code.Recivers.Light;

namespace CommandPattern.Code.Commands
{
    class LightOffCommand : ICommand
    {
        Light light;
        public LightOffCommand(IControlebel light)
        {
            this.light = (Light)light;
        }
        public void Execute()
        {
            if (this.light != null)
            {
                this.light.Off();
            }
        }

        public void UnExecute()
        {
            if (this.light != null)
            {
                this.light.On();
            }
        }
    }
}
