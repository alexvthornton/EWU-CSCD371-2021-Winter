using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_nullIJokeOutput_ArgumentNullException()
        {
            Jester jester = new Jester(new JokeService(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_nullIJokeService_ArgumentNullException()
        {
            Jester jester = new Jester(null, new JokeOutput());
        }
    }
}
