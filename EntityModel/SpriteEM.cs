using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using EntityLayer;

namespace EntityModel
{
    public class SpriteEM
    {
        public static (int, int) calculateMaxHorizontal(List<Bitmap> bitmaps)
        {
            int w = 0;
            int h = 0;
            foreach (Bitmap bitmap in bitmaps)
            {
                w += bitmap.Width + 1;
                h = h > bitmap.Height ? h : bitmap.Height;
            }
            return (w, h);
        }
        public static (int, int) calculateMaxVertical(List<Bitmap> bitmaps)
        {
            int w = 0;
            int h = 0;
            foreach (Bitmap bitmap in bitmaps)
            {
                w = w > bitmap.Width ? w : bitmap.Width;
                h += bitmap.Height;
            }
            return (w, h);
        }

        public static Bitmap getPrintHorizontal(SpriteEL spriteEL)
        {
            (int, int) maxSize = calculateMaxHorizontal(spriteEL.Images);
            Bitmap outputImage = new Bitmap(maxSize.Item1, maxSize.Item2, PixelFormat.Format32bppPArgb);
            int px = 0;

            foreach (Bitmap frameImage in spriteEL.Images)
            {
                Point position = new Point(px, 0);
                using (Graphics graphics = Graphics.FromImage(outputImage))
                {
                    graphics.DrawImage(frameImage, new Rectangle(position, frameImage.Size), new Rectangle(new Point(), frameImage.Size), GraphicsUnit.Pixel);
                }
                px += frameImage.Width + 1;
            }
            return outputImage;
        }
        public static Bitmap getPrintVertical(SpriteEL spriteEL)
        {
            (int, int) maxSize = calculateMaxVertical(spriteEL.Images);
            Bitmap outputImage = new Bitmap(maxSize.Item1, maxSize.Item2, PixelFormat.Format32bppPArgb);
            int py= 0;

            foreach (Bitmap frameImage in spriteEL.Images)
            {
                Point position = new Point(0, py);
                using (Graphics graphics = Graphics.FromImage(outputImage))
                {
                    graphics.DrawImage(frameImage, new Rectangle(position, frameImage.Size), new Rectangle(new Point(), frameImage.Size), GraphicsUnit.Pixel);
                }
                py += frameImage.Height;
            }
            return outputImage;
        }
        
    }
}
