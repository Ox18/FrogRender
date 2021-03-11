using EntityLayer;
using EntityModel;
using System.Drawing;
namespace FrogRender
{
    public class SpriteFR
    {
        public static Bitmap getPrintHorizontal(SpriteEL spriteEL)
        {
            return SpriteEM.getPrintHorizontal(spriteEL);
        }
        public static Bitmap getPrintVertical(SpriteEL spriteEL)
        {
            return SpriteEM.getPrintVertical(spriteEL);
        }
    }
}
