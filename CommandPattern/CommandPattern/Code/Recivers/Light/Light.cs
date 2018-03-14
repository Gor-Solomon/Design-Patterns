using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace CommandPattern.Code.Recivers.Light
{
    class Light : IControlebel
    {
        LightWindow window;
        public Light(Window mainWindow)
        {
            window = new LightWindow();
            window.Show();
            mainWindow.Closed += (e,s) => window.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Send);
        }
        public void On()
        {
            window.Dispatcher.Invoke(new Action(() =>  window.LightEllips.Fill = new SolidColorBrush(Colors.Yellow) ));
        }

        public void Off()
        {
            window.Dispatcher.Invoke(new Action(() => window.LightEllips.Fill = new SolidColorBrush(Colors.White)));
        }
    }
}
