using PNGCore.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PNGCore
{
    public abstract class Chunk
    {
        protected byte[] _type;
        protected byte[] _data;

         public virtual byte[] ToBytes()
        {
            List<byte> result = new List<byte>();
            byte[] length = BitConverter.GetBytes(_data.Length);
            Array.Reverse(length);
            result.AddRange(length);
            result.AddRange(_type);
            result.AddRange(_data);

            List<byte> listToCrc32 = new List<byte>();
            listToCrc32.AddRange(_type);
            listToCrc32.AddRange(_data);
            var hasher = new Crc32();
            using (var stream = new MemoryStream(listToCrc32.ToArray()))
            {
                result.AddRange(hasher.ComputeHash(stream));
            }

            return result.ToArray();
        }
    }
}
