using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PNGCore.Chunks
{
    public class InternationalTextualDataChunk : Chunk
    {
        public String Keyword { get; set; }
        public byte CompressionFlag { private set; get; }
        public byte CompressionMethod { private set; get; }
        public String LanguageTag { private set; get; }
        public String TranslatedKeyword { get; set; }
        public String Text { get; set; }

        public InternationalTextualDataChunk(byte[] Data)
        {
            _type = new byte[] {105,74,88,116};
            _data = Data;
            ReadData(Data);
        }

        private void ReadData(byte[] Data)
        {
            int index = 0;
            String keyword = String.Empty;
            String flagMethodLanguage = String.Empty;
            String translatedKeyword = String.Empty;
            String text = String.Empty;

            //Get keyword
            while(!Encoding.ASCII.GetString(new byte[] { Data[index] }).Equals("\0"))
            {
                Keyword += Convert.ToChar(Data[index]);
                index++;
            }

            //Over null
            index++;

            CompressionFlag = Data[index];
            index++;

            CompressionMethod = Data[index];
            index++;

            while (!Encoding.ASCII.GetString(new byte[] { Data[index] }).Equals("\0"))
            {
                LanguageTag += Convert.ToChar(Data[index]);
                index++;
            }
            index++;

            while (!Encoding.ASCII.GetString(new byte[] { Data[index] }).Equals("\0"))
            {
                LanguageTag += Convert.ToChar(Data[index]);
                index++;
            }
            index++;

            while (index<Data.Length)
            {
                Text += Convert.ToChar(Data[index]);
                index++;
            }
            

        }

    }
}
