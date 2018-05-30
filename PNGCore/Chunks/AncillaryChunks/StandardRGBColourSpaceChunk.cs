using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class StandardRGBColourSpaceChunk : Chunk
    {
        public StandardRGBColourSpaceChunk(byte[] Data)
        {
            _type = new byte[] { 115, 82, 71, 66 };
            _data = Data;
        }
    }
}
