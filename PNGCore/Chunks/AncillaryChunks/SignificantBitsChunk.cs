using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class SignificantBitsChunk : Chunk
    {
        public SignificantBitsChunk (byte[] Data)
        {
            _type = new byte[] { 115, 66, 73, 84 };
            _data = Data;
        }

    }
}
