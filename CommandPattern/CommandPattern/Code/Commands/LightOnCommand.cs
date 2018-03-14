using CommandPattern.Code.Recivers;
using CommandPattern.Code.Recivers.Light;

namespace CommandPattern.Code.Commands
{
    class LightOnCommand : ICommand
    {
        Light light;
        public LightOnCommand(IControlebel light)
        {
            this.light = (Light) light;
        }
        public void Execute()
        {
            if (this.light != null)
            {
                this.light.On();
            }
        }

        public void UnExecute()
        {
            if (this.light != null)
            {
                this.light.Off();
            }
        }
    }
}
