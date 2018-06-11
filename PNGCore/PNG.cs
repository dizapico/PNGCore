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
            ReadStreamToChunks(ImageStream);
            
        }

        public PNG(String FileName)
        {
            using (FileStream fileStream = new FileStream(FileName,FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                ReadStreamToChunks(fileStream);
            }
        }

        private void ReadStreamToChunks(Stream ImageStream)
        {
            ImageStream.Read(_header, 0, _header.Length);
            while (ImageStream.Position < ImageStream.Length)
            {
                Chunk aux = ChunkFromStream(ImageStream);
                if (aux != null)
                {
                    _chunks.Add(aux);
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

        public void AddTextualData(Chunk TextualData)
        {
            if(TextualData.GetType() == typeof(InternationalTextualDataChunk)
                || TextualData.GetType() == typeof(TextualDataChunk)
                || TextualData.GetType() == typeof(CompressedTextualDataChunk))
            {
                Chunk auxChunk =_chunks.FindLast(chunk => chunk.GetType() == TextualData.GetType());
                if(auxChunk== null)
                {
                    _chunks.Insert(_chunks.Count - 1, TextualData);
                }
            }
            

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
