using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class TransparencyChunk : Chunk
    {
        public TransparencyChunk(byte[] Data)
        {
            _type = new byte[] { 116, 82, 78, 83 };
            _data = Data;
        }

    }
}
