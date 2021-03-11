using System.Drawing;

namespace EntityLayer
{
    public class DecompressImg
    {
        private Bitmap image;
        private (int, int) pivot;
        private (int, int) riderOffSet;
        private (int, int) realRiderOffSet;
        
        public DecompressImg() { }

        public DecompressImg(Bitmap image, (int, int) pivot, (int, int) riderOffSet)
        {
            this.Image = image;
            this.Pivot = pivot;
            this.RiderOffSet = riderOffSet;
            this.realRiderOffSet = (pivot.Item1 + riderOffSet.Item1, pivot.Item2 + riderOffSet.Item2);
        }

        public Bitmap Image { get => image; set => image = value; }
        public (int, int) Pivot { get => pivot; set => pivot = value; }
        public (int, int) RiderOffSet { get => riderOffSet; set => riderOffSet = value; }
        public (int, int) RealRiderOffSet { get => realRiderOffSet; set => realRiderOffSet = value; }
    }
}
