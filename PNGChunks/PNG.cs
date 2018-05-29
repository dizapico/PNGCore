using System;
using System.Collections.Generic;
using System.IO;

namespace PNGChunks
{
    public class PNG
    {
        private readonly byte[] _header = new byte[8];
        private readonly IList<Chunk> _chunks;

        public PNG(Stream ImageStream)
        {
            //Paso el stream a lista de chunks
        }

        private Chunk ChunkFromStream(Stream Stream)
        {
            byte[] length = ReadBytes(Stream, 4);
            byte[] type = ReadBytes(Stream, 4);
            Array.Reverse(length);
            byte[] data = ReadBytes(Stream, BitConverter.ToInt32(length, 0));

            //Jump CRC data
            Stream.Seek(4, SeekOrigin.Current);

            return new Chunk(type, data);
        }

        private byte[] ReadBytes(Stream stream, int n)
        {
            var buffer = new byte[n];
            stream.Read(buffer, 0, n);
            return buffer;
        }

    }
}
