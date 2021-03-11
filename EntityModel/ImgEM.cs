using System;
using System.Collections.Generic;
using EntityLayer;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace EntityModel
{
    public class ImgEM
    {
        public static ImgEL ImportImg(ImgEL imgEL)
        {
            byte[] imgByteArray = File.ReadAllBytes(imgEL.Filepath);
            Queue<byte> valueQueue = new Queue<byte>();
            for (int i = 0; i < imgByteArray.Length; i++)
            {
                valueQueue.Enqueue(imgByteArray[i]);
            }

            int v0 = valueQueue.DequeueInt32();
            int numberOfImages = valueQueue.DequeueInt32();

            List<DecompressImg> decompressImgs = new List<DecompressImg>();

            for (int i = 0; i < numberOfImages; i++)
            {
                byte[] colorMode = new byte[] { (byte)valueQueue.DequeueInt16(), (byte)valueQueue.DequeueInt16() };
                int width = valueQueue.DequeueInt32();
                int height = valueQueue.DequeueInt32();
                int pivotX = valueQueue.DequeueInt32();
                int pivotY = valueQueue.DequeueInt32();
                int[] v5 = new int[] { valueQueue.DequeueInt16(), valueQueue.DequeueInt16() };
                int[] v6 = new int[] { valueQueue.DequeueInt16(), valueQueue.DequeueInt16() };
                int pilotPivotX = (sbyte)valueQueue.DequeueInt32();
                int pilotPivotY = (sbyte)valueQueue.DequeueInt32();
                int dataStreamLength = valueQueue.DequeueInt32();

                Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
                for (int bitCount = 0, pixelCount = 0; bitCount < dataStreamLength; bitCount += 2, pixelCount++)
                {
                    bitmap.SetPixel(
                        pixelCount % width,
                        pixelCount / width,
                        GetPixelColor(
                            colorMode[0], (short)valueQueue.DequeueInt16()));
                }
                decompressImgs.Add(new DecompressImg(bitmap, (pivotX, pivotY), (pilotPivotX, pilotPivotY)));
            }
            imgEL.Decompress = decompressImgs;
            return imgEL;
        }
        private static Color GetPixelColor(byte colorType, short encodedValue)
        {
            if (encodedValue > 1)
            {
                int kkk = 10;
                kkk++;
            }

            int a = 0, r = 0, g = 0, b = 0;
            switch (colorType)
            {
                case 0:
                    //In case no transparency is being used, 5-6-5 rgb pixel format it is
                    a = 255;
                    r = (encodedValue & 0b1111_1000_0000_0000) >> 8;
                    g = (encodedValue & 0b0000_0111_1110_0000) >> 3;
                    b = (encodedValue & 0b0000_0000_0001_1111) << 3;
                    break;

                case 1:
                    r = (encodedValue & 0b1111_1000_0000_0000) >> 8;
                    g = (encodedValue & 0b0000_0111_1110_0000) >> 3;
                    b = (encodedValue & 0b0000_0000_0001_1111) << 3;
                    if (r == 0 && g == 0 && b == 0)
                        a = 0;
                    else
                        a = 255;
                    break;

                case 2:
                    //In case there is transparency, each color is made of 4 bits
                    a = (encodedValue & 0xF000) >> 8;
                    r = (encodedValue & 0x0F00) >> 4;
                    g = (encodedValue & 0x00F0) >> 0;
                    b = (encodedValue & 0x000F) << 4;

                    a = (int)Math.Ceiling(255f / 240f * a);
                    r = (int)Math.Ceiling(255f / 240f * r);
                    g = (int)Math.Ceiling(255f / 240f * g);
                    b = (int)Math.Ceiling(255f / 240f * b);
                    break;
            }

            return Color.FromArgb(a, r, g, b);
        }
        public static List<Bitmap> getImages(ImgEL imgEL)
        {
            List<Bitmap> bitmaps = new List<Bitmap>();
            foreach (DecompressImg decompress in imgEL.Decompress)
            {
                bitmaps.Add(decompress.Image);
            }
            return bitmaps;
        }
    }
}
