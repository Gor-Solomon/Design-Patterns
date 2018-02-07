using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Code.Decorators
{
    class BlackWhiteImage : ImageDecorator
    {
        public BlackWhiteImage(IimageEffects image) : base(image)
        {
        }

        protected override Bitmap EffectLogic(Bitmap bitmap)
        {
            Bitmap tempBitmap = bitmap;

            int rgb;
            Color c;

            for (int y = 0; y < tempBitmap.Height; y++)
            {
                for (int x = 0; x < tempBitmap.Width; x++)
                {
                    c = tempBitmap.GetPixel(x, y);
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    tempBitmap.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            }

            return tempBitmap;
        }
    }
}
