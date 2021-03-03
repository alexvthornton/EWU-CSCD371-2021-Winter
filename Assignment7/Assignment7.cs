using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Assignment7
{

    static class methods
    {

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


        public static async Task<int> DownloadTextRepeatedlyAsync(int repetitions, params string[] urls)
        {
            List<Task<int>> tasks = new List<Task<int>>();

            return await Task.Run(() =>
            {
                Parallel.For(0, repetitions, i =>
                {
                    tasks.Add(DownloadTextAsync(urls));
                });

                return tasks.Sum(x => x.Result);
            });
        }


    }
}


