using System;
using System.Threading;
using System.Threading.Tasks;

namespace _2020._01._07_UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            Task<int> task = Assignment7.methods.DownloadTextRepeatedlyAsync(10, new ProgressBar(), token,"https://facebook.com", "https://facebook.com");

            tokenSource.Cancel();
            task.Wait();
        }
    }
}
