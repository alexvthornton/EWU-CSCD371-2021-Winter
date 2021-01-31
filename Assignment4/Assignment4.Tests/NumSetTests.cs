using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Assignment4.Tests
{
    [TestClass]
    public class NumSetTests
    {


        [TestMethod]
        public void test()
        {
            
            NumSet ns1 = new NumSet(8, 4, 2, 1);
            NumSet ns2 = new NumSet(8, 2, 4, 1);

            bool res = ns1.Equals(ns2);
            Assert.AreEqual(ns1.GetHashCode(), ns2.GetHashCode());
        }

         [TestMethod]
        public void test1()
        {
            
            NumSet ns1 = new NumSet(8, 4, 2, 1, 1, 0);
            NumSet ns2 = new NumSet(8, 2, 4, 1, 1, 0, 0);

            bool res = ns1.Equals(ns2);
            Assert.AreEqual(ns1.GetHashCode(), ns2.GetHashCode());
        }

        [TestMethod]
        public void test2()
        {
            
            NumSet ns1 = new NumSet(8, 4, 2, 1, 1);
            NumSet ns2 = new NumSet(8, 2, 4, 0, 1);

            bool res = ns1.Equals(ns2);
            Assert.AreEqual(ns1.GetHashCode(), ns2.GetHashCode());
        }

        [TestMethod]
        public void test3()
        {
            
            NumSet ns1 = new NumSet(8, 4, 2, 1);
            NumSet ns2 = new NumSet(8, 4, 2, 1);

            bool res = ns1.Equals(ns2);
            Assert.AreEqual(ns1.GetHashCode(), ns2.GetHashCode());
        }

    }
}