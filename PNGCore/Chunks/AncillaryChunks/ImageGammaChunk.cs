using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class ImageGammaChunk : Chunk
    {
        public ImageGammaChunk(byte[] Data)
        {
            _type = new byte[] { 103, 65, 77, 65 };
            _data = Data;
        }

    }
}
