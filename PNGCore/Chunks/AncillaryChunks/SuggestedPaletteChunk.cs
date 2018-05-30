using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class SuggestedPaletteChunk : Chunk
    {
        public SuggestedPaletteChunk(byte[] Data)
        {
            _type = new byte[] { 115, 80, 76, 84 };
            _data = Data;
        }

    }
}
