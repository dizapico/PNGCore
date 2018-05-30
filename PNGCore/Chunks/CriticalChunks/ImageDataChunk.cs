using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class ImageDataChunk : Chunk
    {
        public ImageDataChunk(byte[] Data)
        {
            _type = new byte[] { 73, 68, 65, 84 };
            _data = Data;
        }
    }
}
