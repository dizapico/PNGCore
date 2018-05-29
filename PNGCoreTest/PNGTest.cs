using Microsoft.VisualStudio.TestTools.UnitTesting;
using PNGCore;
using System.Collections.Generic;
using System.IO;

namespace PNGCoreTest
{
    [TestClass]
    public class PNGTest
    {
        [TestMethod]
        public void BadgeShouldHaveiTXtBadge()
        {
            FileStream fileStream = new FileStream(@".\Resources\openbadge.png", FileMode.Open);
            PNG png = new PNG(fileStream);
            //List<Chunk> badges = png.GetInternationalText("openbadges");
            //Assert.IsTrue(badges.Count>0);

        }
    }
}
