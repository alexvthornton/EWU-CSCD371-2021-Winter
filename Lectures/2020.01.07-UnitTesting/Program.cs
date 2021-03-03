using System;

namespace _2020._01._07_UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Assignment7.methods.DownloadTextRepeatedlyAsync(10, new ProgressBar(), "https://facebook.com", "https://facebook.com").Result);
        }
    }
}
