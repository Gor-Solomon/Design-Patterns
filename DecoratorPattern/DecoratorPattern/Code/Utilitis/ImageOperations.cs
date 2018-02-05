using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace DecoratorPattern.Code
{
    static class ImageOperations
    {
      

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public static BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapImage retval;

            try
            {
                retval = (BitmapImage)Imaging.CreateBitmapSourceFromHBitmap(
                             hBitmap,
                             IntPtr.Zero,
                             Int32Rect.Empty,
                             BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }

            return retval;
        }

        public static Bitmap ControlerImage2Bitmap(IimageEffects image)
        {
            Bitmap bmp;

            //you should not close the stream because the bitmap will use it;
            MemoryStream ms = new MemoryStream();
            
            BitmapEncoder be = image.GetEncoder();
            be.Frames.Add(BitmapFrame.Create((BitmapSource)image.controlerImage.Source));
            be.Save(ms);

            bmp = new Bitmap(ms);

            return bmp;
        }
    }
}
