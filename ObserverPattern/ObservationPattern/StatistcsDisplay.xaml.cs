using ObserverPattern.Classes;
using ObserverPattern.Interfaces;
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

namespace ObserverPattern
{
    /// <summary>
    /// Interaction logic for StatistcsDisplay.xaml
    /// </summary>
    public partial class StatistcsDisplay : Window
    {
        StatisticsDisplay statistcsDisplay;
        WhetherData whetherData;
        public StatistcsDisplay()
        {
            InitializeComponent();
        }

        public StatistcsDisplay(IObservebel observebel)
        {
            statistcsDisplay = new StatisticsDisplay(observebel);
            statistcsDisplay.ShowEvent += updateShow;
            Closing += statistcsDisplay_Closing;
            InitializeComponent();
            ccCb.IsChecked = true;
            statistcsDisplay.observebel.Subscribe(statistcsDisplay);
        }

     
        public void updateShow()
        {
            Dispatcher.Invoke(() =>
            {
                if (this.IsEnabled)
                {
                    whetherData = statistcsDisplay.AvarageData;

                    tbHumidty1.Text = whetherData.humidety.ToString();
                    tbPressure1.Text = whetherData.presur.ToString();
                    tbTempreature1.Text = whetherData.temp.ToString();

                    tbNumberOfRecords.Text = string.Format("Number of\nrecords: {0}", statistcsDisplay.recordCount);
                }
            });
        }

        private void ccCb_Checked(object sender, RoutedEventArgs e)
        {
            statistcsDisplay.observebel.Subscribe(statistcsDisplay);
        }

        private void ccCb_Unchecked(object sender, RoutedEventArgs e)
        {
            statistcsDisplay.observebel.UnSubscribe(statistcsDisplay);
        }

        private void statistcsDisplay_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            statistcsDisplay.observebel.UnSubscribe(statistcsDisplay);
            statistcsDisplay.ShowEvent -= updateShow;
        }
    }
}

