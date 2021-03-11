using EntityLayer;
using EntityModel;
using System.Drawing;
using System.Collections.Generic;

namespace FrogRender
{
    public class ImgFR
    {
        public static ImgEL ImportImg(ImgEL imgEL)
        {
            return ImgEM.ImportImg(imgEL);
        }
        public static List<Bitmap> getImages(ImgEL imgEL)
        {
            return ImgEM.getImages(imgEL);
        }
    }
}
