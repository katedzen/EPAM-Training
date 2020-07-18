using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetukhovaTask1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetukhovaTask1.Tests
{
    [TestClass()]
    public class NodEvklidTests
    {
        [TestMethod()]
        public void EvklidAlg_15and30_15Returned()
        {
            var res = NodEvklid.EvklidAlg(15, 30, out long timeAlive);

            Assert.AreEqual(15, res);
        }

        [TestMethod()]
        public void EvklidAlg_42and84and49_7Returned()
        {
            var res = NodEvklid.EvklidAlg(42, 84, 49);

            Assert.AreEqual(7, res);
        }

        [TestMethod()]
        public void EvklidAlg_150and16and40and24_2Returned()
        {
            var res = NodEvklid.EvklidAlg(150, 16, 40, 24);

            Assert.AreEqual(2, res);
        }

        [TestMethod()]
        public void EvklidAlg_80and64and1600and500and72_4Returned()
        {
            var res = NodEvklid.EvklidAlg(80, 64, 1600, 500, 72);

            Assert.AreEqual(4, res);
        }

        [TestMethod()]
        public void BinaryEvklidAlg_0and3_3Returned()
        {
            var res = NodEvklid.BinaryEvklidAlg(0, 3, out long timeAlive);

            Assert.AreEqual(3, res);
        }

        [TestMethod()]
        public void BinaryEvklidAlg_5and0_5Returned()
        {
            var res = NodEvklid.BinaryEvklidAlg(5,0, out long timeAlive);

            Assert.AreEqual(5, res);
        }

        [TestMethod()]
        public void BinaryEvklidAlg_5and5_5Returned()
        {
            var res = NodEvklid.BinaryEvklidAlg(5, 5, out long timeAlive);

            Assert.AreEqual(5, res);
        }

        [TestMethod()]
        public void BinaryEvklidAlg_1and5_1Returned()
        {
            var res = NodEvklid.BinaryEvklidAlg(1, 5, out long timeAlive);

            Assert.AreEqual(1, res);
        }

        [TestMethod()]
        public void BinaryEvklidAlg_10and5_5Returned()
        {
            var res = NodEvklid.BinaryEvklidAlg(10, 5, out long timeAlive);

            Assert.AreEqual(5, res);
        }

        [TestMethod()]
        public void CompareAlgorithmTimeTest_25and50_TrueReturned()
        {
            var res = NodEvklid.CompareAlgorithmTime(25, 50, out long[] timeStatistic);

            Assert.AreEqual(true, res);
        }
    }
}