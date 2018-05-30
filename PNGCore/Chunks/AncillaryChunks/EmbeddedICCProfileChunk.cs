using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class EmbeddedICCProfileChunk : Chunk
    {
        public EmbeddedICCProfileChunk(byte[] Data)
        {
            _type = new byte[] { 105, 67, 67, 80 };
            _data = Data;
        }
    }
}
