using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class CompressedTextualDataChunk : Chunk
    {
        public CompressedTextualDataChunk(byte[] Data)
        {
            _type = new byte[] { 122, 84, 88, 116 };
            _data = Data;
        }

    }
}
