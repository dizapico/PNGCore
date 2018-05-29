using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PNGCore.Chunks;

namespace PNGCore
{
    public class PNG
    {
        private readonly byte[] _header = new byte[8];
        private readonly IList<Chunk> _chunks = new List<Chunk>();

        public PNG(Stream ImageStream)
        {
            ImageStream.Read(_header, 0, _header.Length);
            while(ImageStream.Position < ImageStream.Length)
            {
                _chunks.Add(ChunkFromStream(ImageStream));
            }
            
        }

        public void AddInternationalText(String keyword, String text)
        {
            // 1-79     (keyword)
            // 1        (null character)
            // 1        (compression flag)
            // 1        (compression method)
            // 0+       (language)
            // 1        (null character)
            // 0+       (translated keyword)
            // 1        (null character)
            // 0+       (text)

            //var typeBytes = Encoding.UTF8.GetBytes("iTXt");
            //var keywordBytes = Encoding.UTF8.GetBytes(keyword);
            //var textBytes = Encoding.UTF8.GetBytes(text);
            //var nullByte = BitConverter.GetBytes('\0')[0];
            //var zeroByte = BitConverter.GetBytes(0)[0];

            //var data = new List<byte>();

            //data.AddRange(keywordBytes);
            //data.Add(nullByte);
            //data.Add(zeroByte);
            //data.Add(zeroByte);
            //data.Add(nullByte);
            //data.Add(nullByte);
            //data.AddRange(textBytes);

            //var chunk = new Chunk(typeBytes, data.ToArray());

            //_chunks.Insert(1, chunk);
        }

        public List<Chunk> GetInternationalText(String Keyword)
        {
            //List<Chunk> aux = new List<Chunk>();
            //foreach (var chunk in _chunks)
            //{
            //    if(chunk.GetChunkType().Equals(ChunkType.iTXt) && chunk.GetKeyword().Equals(Keyword))
            //    {
            //        aux.Add(chunk);
            //    }
            //}

            //return aux;
            return null;
        }

        private Chunk ChunkFromStream(Stream Stream)
        {
            byte[] length = ReadBytes(Stream, 4);
            byte[] type = ReadBytes(Stream, 4);
            Array.Reverse(length);
            byte[] data = ReadBytes(Stream, BitConverter.ToInt32(length, 0));

            //Jump CRC data
            Stream.Seek(4, SeekOrigin.Current);
            if (Encoding.UTF8.GetString(type).Equals("iTXt"))
            {
                return new InternationalTextualDataChunk(data);
            }
            else
            {
                return null;
            }


            //return new InternationalTextualDataChunk(data);
        }

        private byte[] ReadBytes(Stream stream, int n)
        {
            var buffer = new byte[n];
            stream.Read(buffer, 0, n);
            return buffer;
        }

    }
}
