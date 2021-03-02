using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            Parallel.For(0, repetitions, i =>
            {
                tasks.Add(DownloadTextAsync(urls));
            });

            var results = await Task.WhenAll(tasks);

            int sum = 0;
            for (int i = 0; i < results.Length; i++)
            {
                sum += results[i];
            }

            return sum;
        }

    }
}


