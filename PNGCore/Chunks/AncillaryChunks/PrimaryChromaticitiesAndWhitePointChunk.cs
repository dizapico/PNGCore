using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class PrimaryChromaticitiesAndWhitePointChunk : Chunk
    {

        public PrimaryChromaticitiesAndWhitePointChunk(byte[] Data)
        {
            _type = new byte[] { 99, 72, 82, 77 };
            _data = Data;
        }
    }
}
