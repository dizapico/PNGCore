using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using PNGChunks.Exceptions;
using PNGCore.Chunks;

namespace PNGCore
{
    public class PNG
    {
        private readonly byte[] _header = new byte[8];
        //readonly
        private List<Chunk> _chunks = new List<Chunk>();

        public PNG(Stream ImageStream)
        {
            ImageStream.Read(_header, 0, _header.Length);
            while(ImageStream.Position < ImageStream.Length)
            {
                Chunk aux = ChunkFromStream(ImageStream);
                if(aux != null)
                {
                    _chunks.Add(aux);
                }
                

            }
            
        }

        public PNG(String FileName)
        {
            using (FileStream fileStream = new FileStream(FileName,FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                fileStream.Read(_header, 0, _header.Length);
                while (fileStream.Position < fileStream.Length)
                {
                    Chunk aux = ChunkFromStream(fileStream);
                    if (aux != null)
                    {
                        _chunks.Add(aux);
                    }
                }
            }
        }

        public byte[] ToBytes()
        {
            List<byte> pngSignature = new List<byte>() { 137, 80, 78, 71, 13, 10, 26, 10 };
            List<byte> result = new List<byte>();
            result.AddRange(pngSignature);
            foreach(Chunk chunk in _chunks)
            {
                result.AddRange(chunk.ToBytes());
            }

            return result.ToArray();
        }

        //CartonPiedra
        public void AddChunk(Chunk Chunk)
        {
            List<Chunk> aux = new List<Chunk>();
            foreach (Chunk chunk in _chunks)
            {
                if (chunk.GetType().Equals(typeof(PhysicalPixelDimensionsChunk)))
                {
                    aux.Add(Chunk);
                }
                aux.Add(chunk);
            }
            _chunks = aux;
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
            List<Chunk> aux = new List<Chunk>();
            foreach (var chunk in _chunks)
            {
                if (chunk.GetType() == typeof(InternationalTextualDataChunk)
                    && ((InternationalTextualDataChunk)chunk).Keyword.Equals(Keyword))
                {
                    aux.Add(chunk);
                }
            }

            return aux;
        }

        private Chunk ChunkFromStream(Stream Stream)
        {
            byte[] length = ReadBytes(Stream, 4);
            byte[] type = ReadBytes(Stream, 4);
            Array.Reverse(length);
            byte[] data = ReadBytes(Stream, BitConverter.ToInt32(length, 0));

            //Jump CRC data
            Stream.Seek(4, SeekOrigin.Current);

            switch (Encoding.UTF8.GetString(type))
            {
                case "IHDR":
                    return new ImageHeaderChunk(data);
                case "PLTE":
                    return new PaletteChunk(data);
                case "IDAT":
                    return new ImageDataChunk(data);
                case "IEND":
                    return new ImageTrailerChunk(data);
                case "tRNS":
                    return new TransparencyChunk(data);
                case "cHRM":
                    return new PrimaryChromaticitiesAndWhitePointChunk(data);
                case "gAMA":
                    return new ImageGammaChunk(data);
                case "iCCP":
                    return new EmbeddedICCProfileChunk(data);
                case "sBIT":
                    return new SignificantBitsChunk(data);
                case "sRGB":
                    return new StandardRGBColourSpaceChunk(data);
                case "tEXt":
                    return new TextualDataChunk(data);
                case "xTXt":
                    return new CompressedTextualDataChunk(data);
                case "iTXt":
                    return new InternationalTextualDataChunk(data);
                case "bKGD":
                    return new BackgroundColourChunk(data);
                case "hIST":
                    return new ImageHistogramChunk(data);
                case "pHYs":
                    return new PhysicalPixelDimensionsChunk(data);
                case "sPLT":
                    return new SuggestedPaletteChunk(data);
                case "tIME":
                    return new ImageLastModificationTimeChunk(data);
                default:
                    throw new InvalidPNGFormatException();

            }
            
        }

        private byte[] ReadBytes(Stream stream, int n)
        {
            var buffer = new byte[n];
            stream.Read(buffer, 0, n);
            return buffer;
        }

    }
}
