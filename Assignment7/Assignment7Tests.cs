using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7
{
    [TestClass]
    public class Assignment7Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
           
            Assert.AreEqual(0, Assignment7.methods.DownloadTextAsync("https://google.com", "https://google.com", "https://google.com", "https://google.com").Result);
        }
    }
}