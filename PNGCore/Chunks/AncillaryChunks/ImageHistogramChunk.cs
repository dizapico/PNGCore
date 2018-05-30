using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class ImageHistogramChunk : Chunk
    {
        public ImageHistogramChunk (byte[] Data)
        {
            _type = new byte[] { 104, 73, 83, 84 };
            _data = Data;
        }
    }
}
