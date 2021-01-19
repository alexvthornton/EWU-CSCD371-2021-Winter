using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {

        private string filePath;


        public FileLogger(string filePath)
        {

            this.filePath = filePath;
        }

        override
        public void Log(LogLevel logLevel, string message)
        {
            TextWriter tw = new StreamWriter(filePath, true);
            
            string res = String.Format("{0} {1} {2}: {3}", DateTime.Now.ToString(), base.ClassName, logLevel, message);

            tw.WriteLine(res);
            tw.Close(); 
        }

    }
}