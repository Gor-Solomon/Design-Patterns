using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DecoratorPattern.Code
{
    interface IimageEffects
    {
        Bitmap ApplyEffect();
        BitmapEncoder GetEncoder();
        System.Windows.Controls.Image controlerImage { get; set; }
    }
}
