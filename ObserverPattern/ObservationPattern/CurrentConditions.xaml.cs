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
using ObserverPattern.Interfaces;
using ObserverPattern.Classes;

namespace ObserverPattern
{
    /// <summary>
    /// Interaction logic for CurrentConditions.xaml
    /// </summary>
    public partial class CurrentConditions : Window
    {
        CuurentConditionsDisplay currentCondition;
        WhetherData whetherData;
        public CurrentConditions()
        {
            InitializeComponent();
        }

        public CurrentConditions(IObservebel observebel)
        {
            currentCondition = new CuurentConditionsDisplay(observebel);
            currentCondition.ShowEvent += updateShow;
            Closing += CurrentConditions_Closing;
            InitializeComponent();
            ccCb.IsChecked = true;
            currentCondition.observebel.Subscribe(currentCondition);
            
        }

        private void CurrentConditions_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            currentCondition.observebel.UnSubscribe(currentCondition);
            currentCondition.ShowEvent -= updateShow;
        }
        public void updateShow()
        {
            Dispatcher.Invoke(() =>
            {
                if (this.IsEnabled)
                {
                    whetherData = currentCondition.whetherData;

                    tbHumidty1.Text = whetherData.humidety.ToString();
                    tbPressure1.Text = whetherData.presur.ToString();
                    tbTempreature1.Text = whetherData.temp.ToString();
                }
            });
        }

        private void ccCb_Checked(object sender, RoutedEventArgs e)
        {
            currentCondition.observebel.Subscribe(currentCondition);
        }

        private void ccCb_Unchecked(object sender, RoutedEventArgs e)
        {
            currentCondition.observebel.UnSubscribe(currentCondition);
        }
    }
}
