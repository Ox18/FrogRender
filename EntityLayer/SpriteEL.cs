using System.Collections.Generic;
using System.Drawing;

namespace EntityLayer
{
    public class SpriteEL
    {
        private List<Bitmap> images;

        public SpriteEL(List<Bitmap> images)
        {
            this.images = images;
        }

        public List<Bitmap> Images { get => images; set => images = value; }
    }
}
