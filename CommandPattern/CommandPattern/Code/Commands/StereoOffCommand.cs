using CommandPattern.Code.Recivers;
using CommandPattern.Code.Recivers.Stereo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Code.Commands
{
    class StereoOffCommand : ICommand
    {
        Stereo stereo;

        public StereoOffCommand(IControlebel stereo)
        {
            this.stereo = (Stereo)stereo;
        }
        public void Execute()
        {
            stereo.Off();
        }

        public void UnExecute()
        {
            stereo.SetCD("Code\\Recivers\\Stereo\\StairwayToHeaven.mp3");
            stereo.On();
            stereo.SetVolume(30);
        }
    }
}
