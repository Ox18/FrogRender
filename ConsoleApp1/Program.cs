using System;
using FrogRender;
using System.IO;
using EntityLayer;
using System.Drawing;


namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please, insert the path of file img:");
                    string directoryImg = Console.ReadLine();

                    // Instance of Img
                    Console.WriteLine("Creating IMG object...");
                    ImgEL imgEL = new ImgEL(directoryImg);

                    // Importing Img
                    Console.WriteLine("Importing...");
                    imgEL = ImgFR.ImportImg(imgEL);

                    // Read all images
                    Console.WriteLine("Read all images...");
                    SpriteEL spriteEL = new SpriteEL(ImgFR.getImages(imgEL));

                    // Rendering images horizontally
                    Console.WriteLine("Rendering images...");
                    Bitmap bitmap = SpriteFR.getPrintHorizontal(spriteEL);

                    // Save image
                    Console.WriteLine("Please, enter the folder where the image will be saved:");
                    string directorySave = Console.ReadLine();
                    bitmap.Save(Path.Combine(directorySave, "output.png"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sorry, an error occurred");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
