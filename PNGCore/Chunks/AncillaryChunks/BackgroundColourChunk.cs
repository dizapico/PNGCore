using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class BackgroundColourChunk : Chunk
    {
        public BackgroundColourChunk (byte[] Data)
        {
            _type = new byte[] { 98, 75, 71, 68 };
            _data = Data;
        }


    }
}
