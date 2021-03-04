using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7
{
    [TestClass]
    public class SyncCountTests
    {
        [TestMethod]
        public void CountUnsynchronized_GivenSmallInteger_IsNotSynchronized_ReturnsZero()
        {
            string[] input = { "1000" };
            Assert.AreEqual<int>(0, Program.CountUnsynchronized(input));
        }

        [TestMethod]
        public void CountUnsynchronized_GivenLargeInteger_IsNotSynchronized_NotReturnsZero()
        {
            string[] input = { "1000000" };
            Assert.AreNotEqual<int>(0, Program.CountUnsynchronized(input));
        }

        [TestMethod]
        public void CountLock_GivenSmallInteger_ReturnsZero()
        {
            string[] input = { "1000" };
            Assert.AreEqual<int>(0, Program.CountLock(input));
        }

        [TestMethod]
        public void CountLock_GivenLargeInteger_ReturnsZero()
        {
            string[] input = { "1000000" };
            Assert.AreEqual<int>(0, Program.CountLock(input));
        }

        [TestMethod]
        public void CountInterlocked_GivenSmallInteger_ReturnsZero()
        {
            string[] input = { "1000" };
            Assert.AreEqual<int>(0, Program.CountInterlocked(input));
        }

        [TestMethod]
        public void CountInterlocked_GivenLargeInteger_ReturnsZero()
        {
            string[] input = { "100000" };
            Assert.AreEqual<int>(0, Program.CountInterlocked(input));
        }
        
        // If 
        [TestMethod]
        public void CountThreadLocal_GivenSmallInteger_ReturnsInputValue()
        {
            string[] input = { "1000" };
            Assert.AreEqual<int>(1000, Program.CountThreadLocal(input));
        }

        [TestMethod]
        public void CountThreadLocal_GivenLargeInteger_ReturnsInputValue()
        {
            string[] input = { "1000000" };
            Assert.AreEqual<int>(1000000, Program.CountThreadLocal(input));
        }
    }
}
