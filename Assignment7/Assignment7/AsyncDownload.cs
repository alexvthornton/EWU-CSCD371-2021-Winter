using System;
using System.Net;
using System.Threading.Tasks;

namespace Assignment7
{

    public static class AsyncDownload
    {
        private static readonly object Locker  = new ();
        public static async Task<int> DownloadTextAsync(params string[] urls)
        {
            // calls System.Next.WebClient.DownloadString() 
            // returns total number of characters downloaded from all urls

            if(urls is null){
                throw new ArgumentNullException(nameof(urls));
            }

            var client = new WebClient();

            return await Task.Run( async () =>
            {
                int total = 0;
                foreach (string url in urls)
                {
                    total += await Task.Run(() => client.DownloadString(url).Length);
                }
                return total;
            });

        }


        public static async Task<int> DownloadTextRepeatedlyAsync(int repetitions, IProgress<double> progress, ParallelOptions position, params string[] urls)
        {
            if (progress == null) throw new ArgumentNullException(nameof(progress));
            if(repetitions < 0){
                throw new ArgumentException(nameof(repetitions));
            }
            if(progress is null){
                throw new ArgumentNullException(nameof(progress));
            }

            return await Task.Run( () =>
            {
                int total = 0;
                int count = 1;
                Parallel.For(0, repetitions, position, (i, state) => {
                
                    position.CancellationToken.ThrowIfCancellationRequested();

                    lock(Locker)
                    {
                        total += DownloadTextAsync(urls).Result;
                    }

                    progress.Report((double) count++ / repetitions);
                });
                return total;
            });
               
        }


    }
}