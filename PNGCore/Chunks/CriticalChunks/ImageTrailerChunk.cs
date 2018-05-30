using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class ImageTrailerChunk : Chunk
    {
        public ImageTrailerChunk(byte[] Data)
        {
            _type = new byte[] { 73, 69, 78, 68 };
            _data = Data;
        }
    }
}
