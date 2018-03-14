using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace CommandPattern.Code.Recivers.Garage
{
    class Garage : IControlebel
    {
        GarageWindow window;
        public Garage(Window mainWindow)
        {
            window = new GarageWindow();
            window.Show();
            mainWindow.Closed += (e, s) => window.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Send);
        }
        public void On()
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                window.RC_Door.Height = 40;
                window.RC_Door.Width = 187;
                window.RC_Door.Fill = new SolidColorBrush(Colors.Green);
                Canvas.SetLeft(window.RC_Door, -122);
            }));
        }

        public void Off()
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                window.RC_Door.Height = 137;
                window.RC_Door.Width = 40;
                window.RC_Door.Fill = new SolidColorBrush(Colors.Red);
                Canvas.SetLeft(window.RC_Door, 35);
            }));
        }
    }
}
