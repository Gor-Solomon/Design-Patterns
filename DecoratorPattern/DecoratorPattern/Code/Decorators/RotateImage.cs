using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Code.Decorators
{
    class RotateImage : ImageDecorator
    {
        RotateFlipType flipType;

        public RotateImage(IimageEffects image, RotateFlipType flipType ) : base(image)
        {
            this.flipType = flipType;
        }

        public override Bitmap ApplyEffect()
        {
            Bitmap tempBitmap = this.wrapedImage.ApplyEffect();
            tempBitmap.RotateFlip(flipType);
            return tempBitmap;
        }
    }
}
