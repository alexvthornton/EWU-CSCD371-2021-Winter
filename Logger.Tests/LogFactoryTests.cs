using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_FileLoggerNotConfigured_ReturnNull()
        {
            LogFactory? lf = new LogFactory();
            BaseLogger? baseLogger = lf.CreateLogger(this.GetType().Name);

            Assert.IsNull(baseLogger);
        }

        [TestMethod]
        public void ConfigureFileLogger_path_StoresResultInFileLogger()
        {
            LogFactory? lf = new LogFactory();
            lf.ConfigureFileLogger("Path");
            FileLogger? fileLogger = (FileLogger?)lf.CreateLogger(this.GetType().Name);
            
            string res = "";
            if(fileLogger != null && !string.IsNullOrEmpty(fileLogger.FilePath))
            {
                res = fileLogger.FilePath;
            }
            Assert.AreEqual(res, "Path");
        }

        [TestMethod]
        public void CreateLogger_NameOfClass_StoresResultInBaseLogger()
        {
            LogFactory? lf = new LogFactory();
            lf.ConfigureFileLogger("Path");
            FileLogger? fileLogger = (FileLogger?)lf.CreateLogger(this.GetType().Name);
            
            string res = "";
            if(fileLogger != null && !string.IsNullOrEmpty(fileLogger.ClassName))
            {
                res = fileLogger.ClassName;
            }

            Assert.AreEqual(this.GetType().Name, res);
        }





    }
}
