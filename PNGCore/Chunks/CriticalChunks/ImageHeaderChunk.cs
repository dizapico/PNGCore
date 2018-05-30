using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class ImageHeaderChunk : Chunk
    {

        public ImageHeaderChunk(byte[] Data)
        {
            _type = new byte[] { 73, 72, 68, 82 };
            _data = Data;
        }

        
    }
}
