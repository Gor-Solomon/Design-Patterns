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
using Microsoft.Win32;
using DecoratorPattern.Code;
using DecoratorPattern.Code.Decorators;
using System.IO;
using System.Drawing;
using System.Windows.Interop;

namespace DecoratorPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFile;
        SaveFileDialog saveFile;
        IimageEffects mainImage;

        public MainWindow()
        {
            InitializeComponent();

            openFile = new Microsoft.Win32.OpenFileDialog();
            openFile.DefaultExt = Constants.DefaultPngExt;
            openFile.Filter = Constants.ImageFilesFilter;

            saveFile = new Microsoft.Win32.SaveFileDialog();
            saveFile.DefaultExt = Constants.DefaultPngExt;
            saveFile.Filter = Constants.ImageFilesFilter;

            btnSave.IsEnabled = false;
            blackAndWhite_Button.IsEnabled = false;
            btRotate_Left.IsEnabled = false;
            btRotate_Right.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            openFile.FileName = string.Empty;
            Nullable<bool> result = openFile.ShowDialog();

            if (result == true)
            {
                mainImage = new MainImage(imgDisplayImage,openFile.FileName);
                imgDisplayImage = mainImage.controlerImage;
                tbFileName.Text = openFile.SafeFileName;

                btnSave.IsEnabled = true;
                blackAndWhite_Button.IsEnabled = true;
                btRotate_Left.IsEnabled = true;
                btRotate_Right.IsEnabled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            saveFile.FileName = openFile.SafeFileName;
            saveFile.CheckPathExists = true;
            Nullable<bool> result = saveFile.ShowDialog();

            if (result == true)
            {
                ImageOperations.ControlerImage2Bitmap(mainImage).Save(saveFile.FileName);
            }
        }

        private void blackAndWhite_Button_Click(object sender, RoutedEventArgs e)
        {
            mainImage = new BlackWhiteImage(mainImage);
            Bitmap dd = mainImage.ApplyEffect();
            imgDisplayImage.Source = ImageOperations.Bitmap2ImageSource(dd);
        }

        private void btRotate_Left_Click(object sender, RoutedEventArgs e)
        {
            mainImage = new RotateImage(mainImage, RotateFlipType.Rotate90FlipNone);
            Bitmap dd = mainImage.ApplyEffect();
            imgDisplayImage.Source = ImageOperations.Bitmap2ImageSource(dd);
        }

        private void btRotate_Right_Click(object sender, RoutedEventArgs e)
        {
            mainImage = new RotateImage(mainImage, RotateFlipType.Rotate90FlipX);
            Bitmap dd = mainImage.ApplyEffect();
            imgDisplayImage.Source = ImageOperations.Bitmap2ImageSource(dd);
        }
    }
}
