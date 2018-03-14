using CommandPattern.Code.Recivers;
using CommandPattern.Code.Recivers.Stereo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommandPattern.Code.Commands
{
    class StereoOnWithCDCommand : ICommand
    {

        Stereo stereo;

        public StereoOnWithCDCommand(IControlebel stereo)
        {
            this.stereo = (Stereo)stereo;
        }
        public void Execute()
        {
            stereo.SetCD("Code\\Recivers\\Stereo\\StairwayToHeaven.mp3");
            stereo.On();
            stereo.SetVolume(30);
        }

        public void UnExecute()
        {
            stereo.Off();
        }
    }
}
