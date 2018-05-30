using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class PhysicalPixelDimensionsChunk : Chunk
    {
        public PhysicalPixelDimensionsChunk(byte[] Data)
        {
            _type = new byte[] { 112, 72, 89, 115 };
            _data = Data;
        }

    }
}
