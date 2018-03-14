using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace CommandPattern.Code.Recivers.Stereo
{
    class Stereo : IControlebel
    {
        StereoWindow stereo;
      //  public bool FileIsOpend;
        public Stereo(Window mainWindow)
        {
            stereo = new StereoWindow();
            stereo.Show();
            mainWindow.Closed += (e, s) => stereo.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Send);
        }
        public void On()
        {
            stereo.mediaPlayer.Play();
        }

        public void Off()
        {
            stereo.mediaPlayer.Pause();
        }

        public void SetCD(string path)
        {
            if(path != stereo.fileName)
            {
                stereo.OpenAudioFile(path);
            }
            
        }

        public void SetVolume(double volume)
        {
            stereo.mediaPlayer.Volume = volume;
        }
    }
}
