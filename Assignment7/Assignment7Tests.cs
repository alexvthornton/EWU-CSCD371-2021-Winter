using System;
using System.Threading;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7
{
    [TestClass]
    public class Assignment7Tests
    {
        public static int DownloadText(params string[] urls){

            var client = new WebClient();
            int total = 0;
            foreach (string url in urls)
            {
                total += client.DownloadString(url).Length;
            }

            return total;
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextAsync_NullUrl_AggregateException()
        {   
            Console.Write(Assignment7.methods.DownloadTextAsync(null).Result);
        }

        [TestMethod]
        public void DownloadTextAsync_NoParams_ZeroLength()
        {   
            Assert.AreEqual<int>(0, Assignment7.methods.DownloadTextAsync().Result);
        }

        [TestMethod]
        public void DownloadTextAsync_ValidParam_SimiarResultSynchronous()
        {   
            Assert.IsTrue(Math.Abs(DownloadText("https://google.com") - Assignment7.methods.DownloadTextAsync("https://google.com").Result) < 1000);
        }

        [TestMethod]
        public void DownloadTextAsync_ParamsArray_SimiarResultSynchronous()
        {   
            Assert.IsTrue(Math.Abs(DownloadText("https://google.com", "https://google.com", "https://google.com") - Assignment7.methods.DownloadTextAsync("https://google.com", "https://google.com", "https://google.com").Result) < 2000);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_negativeRepetitions_AggregateException()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            Assert.AreEqual(0, Assignment7.methods.DownloadTextRepeatedlyAsync(-10, new ProgressBar(), token, "https://facebook.com", "https://facebook.com").Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_NullProgress_AggregateException()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            Assert.AreEqual(0, Assignment7.methods.DownloadTextRepeatedlyAsync(10, null, token, "https://facebook.com", "https://facebook.com").Result);
        }
        
    }
}