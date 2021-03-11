using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrogRender;
using EntityLayer;
using System.Drawing;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ImgEL imgEL = new ImgEL(@"C:\Users\Wilmer\Desktop\mh00008.img");
            imgEL = ImgFR.ImportImg(imgEL);
            SpriteEL spriteEL = new SpriteEL(ImgFR.getImages(imgEL));
            Bitmap bitmap = SpriteFR.getPrintHorizontal(spriteEL);
            bitmap.Save(@"C:\Users\Wilmer\Desktop\mh00008.png");
        }
    }
}
