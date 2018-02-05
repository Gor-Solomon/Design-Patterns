using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DecoratorPattern.Code
{
    class MainImage : IimageEffects
    {
        public Bitmap bitMap;
        
        public string fileExtention;

        public System.Windows.Controls.Image controlerImage { get; set; }

        public MainImage(System.Windows.Controls.Image pcontrolerImage, string fileName)
        {
            controlerImage = pcontrolerImage;
            controlerImage.Source = new BitmapImage(new Uri(fileName));

            if (!controlerImage.IsInitialized)
            {
                controlerImage.BeginInit();
                // bitMap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            fileExtention = fileName.Split(new char[] { '.' })[1].ToLower();

            MemoryStream ms = new MemoryStream();
            BitmapEncoder be = this.GetEncoder();
            be.Frames.Add(BitmapFrame.Create((BitmapSource)controlerImage.Source));
            be.Save(ms);

            bitMap = new Bitmap(ms);
        }

        public BitmapEncoder GetEncoder()
        {
            BitmapEncoder bitmapEncoder = null;

            switch (fileExtention)
            {
                case "png":
                    bitmapEncoder = new PngBitmapEncoder();
                    break;
                case "jpg":
                    bitmapEncoder = new JpegBitmapEncoder();
                    break;
                case "gif":
                    bitmapEncoder = new GifBitmapEncoder();
                    break;
            }

            return bitmapEncoder;
        }


        public Bitmap ApplyEffect()
        {
            return this.bitMap;
        }
    }
}
