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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CommandPattern.Code.Recivers.Light
{
    /// <summary>
    /// Interaction logic for LightWindow.xaml
    /// </summary>
    public partial class LightWindow : Window
    {
        public LightWindow()
        {
            InitializeComponent();
            Title = "Light ID " + this.GetHashCode();
        }
    }
}
