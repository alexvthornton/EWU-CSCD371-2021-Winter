using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment7
{
    [TestClass]
    public class AsyncDownloadTests
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
            Console.Write(AsyncDownload.DownloadTextAsync(null!).Result);
        }

        [TestMethod]
        public void DownloadTextAsync_NoParams_ZeroLength()
        {   
            Assert.AreEqual<int>(0, AsyncDownload.DownloadTextAsync().Result);
        }

        [TestMethod]
        public void DownloadTextAsync_ValidParam_SimilarResultSynchronous()
        {   
            Assert.IsTrue(Math.Abs(DownloadText("https://google.com") - AsyncDownload.DownloadTextAsync("https://google.com").Result) < 1000);
        }

        [TestMethod]
        public void DownloadTextAsync_ParamsArray_SimilarResultSynchronous()
        {   
            Assert.IsTrue(Math.Abs(DownloadText("https://google.com", "https://google.com", "https://google.com") - AsyncDownload.DownloadTextAsync("https://google.com", "https://google.com", "https://google.com").Result) < 2000);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_negativeRepetitions_AggregateException()
        {
            CancellationTokenSource tokenSource = new();
            ParallelOptions parallelOptions = new() {CancellationToken = tokenSource.Token};
            int repetitions = -10;
            Assert.AreEqual(0, AsyncDownload.DownloadTextRepeatedlyAsync(repetitions, new Progress<double>( x => Console.WriteLine(x)), parallelOptions, "https://facebook.com", "https://facebook.com").Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_NullProgress_AggregateException()
        {
            CancellationTokenSource tokenSource = new ();
            ParallelOptions parallelOptions = new() {CancellationToken = tokenSource.Token};
            int repetitions = 10;
            Assert.AreEqual(0, AsyncDownload.DownloadTextRepeatedlyAsync(repetitions, null!, parallelOptions, "https://facebook.com", "https://facebook.com").Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_Cancel_TaskWillBeCancelled()
        {
            CancellationTokenSource tokenSource = new();
            ParallelOptions parallelOptions = new() {CancellationToken = tokenSource.Token};
            int repetitions = 10;
            int result = AsyncDownload.DownloadTextRepeatedlyAsync(repetitions, new Progress<double>( x => CancelTaskAfterProgress( .1, x, tokenSource)),  parallelOptions, "https://facebook.com", "https://facebook.com").Result;
            
        }

        public static void CancelTaskAfterProgress(double progress, double x, CancellationTokenSource tokenSource)
        {
            if(x > progress){
                tokenSource.Cancel();
            }

        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_ValidParams_SimilarResultSynchronous()
        {
            CancellationTokenSource tokenSource = new();
            ParallelOptions parallelOptions = new() {CancellationToken = tokenSource.Token};
            int repetitions = 3;
            int total = 0;
            for(int i = 0; i < repetitions; i++){
                total += DownloadText("https://facebook.com", "https://facebook.com");
            }
            int result = AsyncDownload.DownloadTextRepeatedlyAsync(repetitions, new Progress<double>(Console.WriteLine), parallelOptions, "https://facebook.com", "https://facebook.com").Result;
        
            Assert.IsTrue(Math.Abs(total - result) < 3000);
        }
        
    }
}