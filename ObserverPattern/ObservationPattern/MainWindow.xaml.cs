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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ObserverPattern.Classes;
using System.ComponentModel;

namespace ObserverPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WhetherControler whetherData;
        CurrentConditions ConditionsWindow;
        StatistcsDisplay statisticsWindow;
        ForecastDisplay forecastDisplay;
        public MainWindow()
        {
            InitializeComponent();
            whetherData = new WhetherControler();
            Closing += OnWindowClosing;
        }

        private void btCurrentConditionDisplay_Click(object sender, RoutedEventArgs e)
        {
            ConditionsWindow = new CurrentConditions(whetherData);
            ConditionsWindow.Show();
        }
        private void btStatickDisplay_Click(object sender, RoutedEventArgs e)
        {
            statisticsWindow = new StatistcsDisplay(whetherData);
            statisticsWindow.Show();
        }

        private void btForecastDisplay_Click(object sender, RoutedEventArgs e)
        {
            forecastDisplay = new ForecastDisplay(whetherData);
            forecastDisplay.Show();
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            whetherData.Dispose();

            if (ConditionsWindow != null)
            {
                ConditionsWindow.Close();
            }

            if (statisticsWindow != null)
            {
                statisticsWindow.Close();
            }

            if (forecastDisplay != null)
            {
                forecastDisplay.Close();
            }
        }

    
    }
}
