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
            int repetitions = -10;
            Assert.AreEqual(0, Assignment7.methods.DownloadTextRepeatedlyAsync(repetitions, new Progress<double>( x => Console.WriteLine(x)), token, "https://facebook.com", "https://facebook.com").Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_NullProgress_AggregateException()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            int repetitions = 10;
            Assert.AreEqual(0, Assignment7.methods.DownloadTextRepeatedlyAsync(repetitions, null, token, "https://facebook.com", "https://facebook.com").Result);
        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_Cancel_TaskWillBeCancelled()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            int repetitions = 10;
            int result = Assignment7.methods.DownloadTextRepeatedlyAsync(repetitions, new Progress<double>( x => CancelTaskAfterProgress( .1, x, tokenSource)), token, "https://facebook.com", "https://facebook.com").Result;
            //if the result falls between these numbers we know it started executing but did not finish
            Assert.IsTrue(result > 100000 && result < 1000000);
        }

        public static void CancelTaskAfterProgress(double progress, double x, CancellationTokenSource tokenSource)
        {
            if(x > progress){
                tokenSource.Cancel();
            }

        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_ValidParams_SimiarResultSynchronous()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            int repetitions = 3;
            int total = 0;
            for(int i = 0; i < repetitions; i++){
                total += DownloadText("https://facebook.com", "https://facebook.com");
            }
            int result = Assignment7.methods.DownloadTextRepeatedlyAsync(repetitions, new Progress<double>( x => Console.WriteLine(x)), token, "https://facebook.com", "https://facebook.com").Result;
        
            Assert.IsTrue(Math.Abs(total - result) < 3000);
        }
        
    }
}