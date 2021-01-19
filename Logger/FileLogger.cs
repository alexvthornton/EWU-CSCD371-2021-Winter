using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {

        private string? _filePath;
        public string FilePath
        {
            get
            {
                return _filePath!;
            }
            set => _filePath = value??throw new ArgumentNullException();
        }


        public FileLogger(string filePath)
        {

            FilePath = filePath;
        }

        override
        public void Log(LogLevel logLevel, string message)
        {
            if(!File.Exists(FilePath))
            {
                throw new FileNotFoundException();
            }

            TextWriter tw = new StreamWriter(FilePath, true);

            string res = String.Format("{0} {1} {2}: {3}", DateTime.Now.ToString(), base.ClassName, logLevel, message);

            tw.WriteLine(res);
            tw.Close(); 
        }

    }
}