using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using CommandPattern.Code.Recivers;
using CommandPattern.Code.Commands;
using CommandPattern.Code;
using CommandPattern.Code.Recivers.Garage;

namespace CommandPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InvokerRemoteControl remoteContorl;
        public MainWindow()
        {
            InitializeComponent();
            remoteContorl = new InvokerRemoteControl();
            CommandFactoryMethod factoryMethod = new CommandFactoryMethod(this);

            Code.ICommand on, off;

            factoryMethod.GetCommand(CommandsType.Light, out on, out off);
            remoteContorl.SettCommand(1, on, off);

            factoryMethod.GetCommand(CommandsType.Garage, out on, out off);
            remoteContorl.SettCommand(4, on, off);

        }

        private void Bt_OnBtnPress(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            remoteContorl.OnButtonPress(int.Parse(b.Tag.ToString()));
        }

        private void Bt_OffBtnPress(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            remoteContorl.OffButtonPress(int.Parse(b.Tag.ToString()));
        }

    }
}

