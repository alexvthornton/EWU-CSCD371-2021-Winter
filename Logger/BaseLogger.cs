

namespace Logger
{
    
    public abstract class BaseLogger
    {

        public string ClassName { get; set; }

        public abstract void Log(LogLevel logLevel, string message);
    }

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
            
            string res = System.DateTime.Now.ToString() + base.ClassName + logLevel + message;
        }

    }
        
}
