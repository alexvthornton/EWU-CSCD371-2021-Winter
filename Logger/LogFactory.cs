namespace Logger
{
    public class LogFactory
    {

        private string filePath;

        public BaseLogger CreateLogger(string className)
        {
            if(filePath is null)
                return null;

            return new FileLogger(filePath) {ClassName= className};
        }

        public void ConfigureFileLogger(string filePath){
            this.filePath = filePath;
        }
    }
}
