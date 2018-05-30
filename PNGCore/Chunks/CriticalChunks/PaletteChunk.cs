using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class PaletteChunk : Chunk
    {
        public PaletteChunk(byte[] Data)
        {
            _type = new byte[] { 80, 76, 84, 69 };
            _data = Data;
        }


    }
}
