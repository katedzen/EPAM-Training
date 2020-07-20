using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetukhovaTask1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetukhovaTask1_2.Tests
{
    [TestClass()]
    public class FigureReaderTests
    {
        [TestMethod()]
        public void FindEqualsFigures_figuresSet_lenqthEqual8Waiting()
        {
            FigureReader fReader = new FigureReader("figures.txt");

            int count = fReader.figures.Length;

            Assert.AreEqual(8, count);
        }
    }
}