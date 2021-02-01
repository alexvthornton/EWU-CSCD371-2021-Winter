///Users/alexthornton/Documents/College/CSCD371/EWU-CSCD371-2021-Winter/Assignment4/testFile.txt
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using Assignment4.Writer;

namespace Assignment4.Tests
{
    [TestClass]
    public class SetWriterTests
    {


        [TestMethod]
        public void test()
        {
            
            NumSet ns1 = new NumSet(8, 4, 2, 1, 2, 2, 34, 3, 5, 6, 32 ,23, 1, 34, 55, 6);

            SetWriter sw = new SetWriter("/Users/alexthornton/Documents/College/CSCD371/EWU-CSCD371-2021-Winter/Assignment4/testFile.txt");
            sw.WriteSet(ns1);

            Assert.AreEqual(ns1.GetHashCode(), ns1.GetHashCode());
        }


    }
}