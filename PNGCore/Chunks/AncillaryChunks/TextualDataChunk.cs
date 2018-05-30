using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class TextualDataChunk : Chunk
    {
        public TextualDataChunk(byte[] Data)
        {
            _type = new byte[] { 116, 69, 88, 116 };
            _data = Data;
        }
    }
}
