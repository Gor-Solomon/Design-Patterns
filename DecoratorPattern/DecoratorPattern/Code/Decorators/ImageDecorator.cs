using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DecoratorPattern.Code
{
    abstract class ImageDecorator : IimageEffects
    {
        protected IimageEffects wrapedImage;
        protected bool HaveBeenApplied = false;

        public System.Windows.Controls.Image controlerImage { get { return wrapedImage.controlerImage; } set { wrapedImage.controlerImage = value; } }

        public ImageDecorator(IimageEffects image)
        {
            wrapedImage = image;
        }

        public Bitmap ApplyEffect()
        {
            Bitmap bitmap = wrapedImage.ApplyEffect();

            if (!HaveBeenApplied)
            {
                HaveBeenApplied = true;
                EffectLogic(bitmap);
            }

            return bitmap;
        }

        protected abstract Bitmap EffectLogic(Bitmap bitmap);

        public BitmapEncoder GetEncoder()
        {
            return wrapedImage.GetEncoder();
        }
    }
}
