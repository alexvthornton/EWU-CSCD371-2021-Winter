using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7
{
    [TestClass]
    public class Assignment7Tests
    {
        [TestMethod]
        public void Test_DownloadTextAsync()
        {
           
            Assert.AreEqual(0, Assignment7.methods.DownloadTextAsync("https://facebook.com", "https://facebook.com").Result);
        }

        [TestMethod]
        public void Test_DownloadTextRepeatedlyAsync()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            Assert.AreEqual(0, Assignment7.methods.DownloadTextRepeatedlyAsync(10, new ProgressBar(),"https://facebook.com", "https://facebook.com").Result);
        }
        
    }
}