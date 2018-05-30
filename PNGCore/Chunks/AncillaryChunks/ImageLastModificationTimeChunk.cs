using System;
using System.Collections.Generic;
using System.Text;

namespace PNGCore.Chunks
{
    public class ImageLastModificationTimeChunk : Chunk
    {
        public ImageLastModificationTimeChunk (byte[] Data)
        {
            _type = new byte[] { 116, 73, 77, 69 };
            _data = Data;
        }

    }
}
