using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;


namespace Assignment7
{

    static class methods
    {
        private static Object obj = new object();

        public static async Task<int> DownloadTextAsync(params string[] urls)
        {
            // calls System.Next.WebClient.DownloadString() 
            // returns total number of characters downloaded from all urls
            var client = new WebClient();

            return await Task.Run(() =>
            {
                int total = 0;
                foreach (string url in urls)
                {
                    total += client.DownloadString(url).Length;
                }
                return total;
            });

        }

         public static async Task<int> DownloadTextRepeatedlyAsync(int repetitions, IProgress<double> progress, CancellationToken cancellationToken, params string[] urls)
        {
              return await Task.Run( async () =>
            {
                int total = 0;
                int count = 1;
                for(int i = 0; i <= repetitions && !cancellationToken.IsCancellationRequested; i++)
                {
                    total += await DownloadTextAsync(urls);

                    if (progress != null)
                    {
                    progress.Report((double) count++ / 10);
                    }
           
                }
                return total;
            });
               
        }


    }
}


