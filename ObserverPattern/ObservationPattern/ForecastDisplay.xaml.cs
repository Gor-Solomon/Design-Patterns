using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ObserverPattern.Classes;
using ObserverPattern.Interfaces;

namespace ObserverPattern
{
    /// <summary>
    /// Interaction logic for ForecastDisplay.xaml
    /// </summary>
    public partial class ForecastDisplay : Window , IObserver
    {
        WhetherData whetherData;
        IObservebel observebel;
        public ForecastDisplay()
        {
            InitializeComponent();
        }

        public ForecastDisplay(IObservebel observebel)
        {
            this.observebel = observebel;
            Closing += ForcastDisplayDisplay_Closing;
            InitializeComponent();
            ccCb.IsChecked = true;
            observebel.Subscribe(this);
        }

        private void ccCb_Checked(object sender, RoutedEventArgs e)
        {
            observebel.Subscribe(this);
        }

        private void ccCb_Unchecked(object sender, RoutedEventArgs e)
        {
            observebel.UnSubscribe(this);
        }

        private void ForcastDisplayDisplay_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            observebel.UnSubscribe(this);
        }

        public event showMethod ShowEvent;

        public void Dispose()
        {
            observebel.UnSubscribe(this);
        }

        public void Update()
        {
            Dispatcher.Invoke(() =>
            {
                if (this.IsEnabled)
                {
                    observebel.GetData( out whetherData);

                    tbMorning.Text = (whetherData.humidety * whetherData.temp / whetherData.presur).ToString();
                    tbNoon.Text = (whetherData.humidety * whetherData.temp * whetherData.presur).ToString();
                    tbNight.Text = (whetherData.humidety + whetherData.temp / whetherData.presur).ToString();
                }
            });
        }
    }
}
