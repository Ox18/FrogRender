using System.Collections.Generic;

namespace EntityLayer
{
    public class ImgEL
    {
        private string filepath;
        private List<DecompressImg> decompress;
        
        public ImgEL() { }
        public ImgEL(string filepath)
        {
            Filepath = filepath;
        }
        public ImgEL(string filepath, List<DecompressImg> decompress)
        {
            this.Filepath = filepath;
            this.Decompress = decompress;
        }

        public string Filepath { get => filepath; set => filepath = value; }
        public List<DecompressImg> Decompress { get => decompress; set => decompress = value; }
    }
}
