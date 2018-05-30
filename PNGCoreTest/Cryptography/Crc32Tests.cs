using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PNGCore.Cryptography;

namespace PNGCoreTest.Cryptography
{
    public class Crc32Tests : BaseHashAlgorithmTests
    {
        [TestMethod]
        public void StaticDefaultSeedAndPolynomialWithShortAsciiString()
        {
            var actual = Crc32.Compute(SimpleBytesAscii);

            Assert.AreEqual((UInt32)0x519025e9, actual);
        }

        [TestMethod]
        public void StaticDefaultSeedAndPolynomialWithShortAsciiString2()
        {
            var actual = Crc32.Compute(SimpleBytes2Ascii);

            Assert.AreEqual((UInt32)0x6ee3ad88, actual);
        }

        [TestMethod]
        public void InstanceDefaultSeedAndPolynomialWith12KBinaryFile()
        {
            var hash = GetTestFileHash(Binary12KFileName, new Crc32());

            Assert.AreEqual(0x9865b070, GetBigEndianUInt32(hash));
        }
    }
}
