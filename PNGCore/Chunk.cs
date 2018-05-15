using PNGChunks.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNGChunks
{
    public class Chunk
    {
        private readonly byte[] _type;
        private byte[] _data;

        public Chunk(byte[] Type, byte[] Data)
        {
            _type = Type;
        }

        public ChunkType GetChunkType()
        {
            switch (Encoding.UTF8.GetString(_type))
            {
                case "PLTE":
                    return ChunkType.PLTE;
                case "IDAT":
                    return ChunkType.IDAT;
                case "IEND":
                    return ChunkType.IEND;
                case "tRNS":
                    return ChunkType.tRNS;
                case "cHRM":
                    return ChunkType.cHRM;
                case "gAMA":
                    return ChunkType.gAMA;
                case "iCCP":
                    return ChunkType.iCCP;
                case "sBIT":
                    return ChunkType.sBIT;
                case "sRGB":
                    return ChunkType.sRGB;
                case "iTXt":
                    return ChunkType.iTXt;
                case "tEXt":
                    return ChunkType.tEXt;
                case "zTXt":
                    return ChunkType.zTXt;
                case "bKGD":
                    return ChunkType.bKGD;
                case "hIST":
                    return ChunkType.hIST;
                case "pHYs":
                    return ChunkType.pHYs;
                case "sPLT":
                    return ChunkType.sPLT;
                case "tIME":
                    return ChunkType.tIME;
                default:
                    throw new InvalidPNGFormatException("Invalid chunk type");
            }
        }

        public byte[] GetCharType()
        {
            return _type;
        }

        public String GetKeyword()
        {
            byte[] keyword = null;
            if(GetChunkType().Equals(ChunkType.iTXt)
                || GetChunkType().Equals(ChunkType.zTXt)
                || GetChunkType().Equals(ChunkType.tEXt))
            {
                int index = Array.FindIndex(_data, 0, _data.Length, x => x.Equals("\0"));
                keyword = new byte[index];
                Array.Copy(_data, keyword, index);
            }

            return keyword!= null? Encoding.UTF8.GetString(keyword) : "";
        }

        public String GetData()
        {
            switch (GetChunkType())
            {
                case ChunkType.iTXt:
                    return Encoding.UTF8.GetString(_data);
                default:
                    return "";
            }
        }

        public byte[] GetCharData()
        {
            return _data;
        }
    }
    public enum ChunkType
    {
        PLTE,
        IDAT,
        IEND,
        tRNS,
        cHRM,
        gAMA,
        iCCP,
        sBIT,
        sRGB,
        iTXt,
        tEXt,
        zTXt,
        bKGD,
        hIST,
        pHYs,
        sPLT,
        tIME
    };
}
