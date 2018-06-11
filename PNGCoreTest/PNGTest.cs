using Microsoft.VisualStudio.TestTools.UnitTesting;
using PNGCore;
using PNGCore.Chunks;
using System.Collections.Generic;
using System.IO;

namespace PNGCoreTest
{
    [TestClass]
    public class PNGTest
    {
        [TestMethod]
        public void WriteiTXtWithKeywordAndText()
        {
            PNG png = new PNG(@".\Resources\pngicon.png");

            List<Chunk> iTXts = png.GetInternationalText("test");
            Assert.AreEqual(iTXts.Count, 0);

            string text = "test text";
            InternationalTextualDataChunk iTXt = new InternationalTextualDataChunk("test", text);
            png.AddTextualData(iTXt);
            iTXts = png.GetInternationalText("test");
            Assert.AreEqual(iTXts.Count, 1);

            InternationalTextualDataChunk iTXtFinal = (InternationalTextualDataChunk)iTXts[0];
            Assert.AreEqual(iTXtFinal.Text, text);
        }
    }
}
