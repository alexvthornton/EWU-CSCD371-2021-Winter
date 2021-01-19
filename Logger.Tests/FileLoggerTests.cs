﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileLogger_nullFilePath_ArgumentNullException()
        {
            FileLogger? fileLogger = new FileLogger(null!);
        }

        [TestMethod]
        public void FileLogger_testFilePath()
        {
            FileLogger? fileLogger = new FileLogger("test");
            
            string res = "";
            if(fileLogger != null && !string.IsNullOrEmpty(fileLogger.FilePath))
            {
                res = fileLogger.FilePath;
            }

            Assert.AreEqual(res, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Log_InvalidFile_FIleNotFoundException()
        {

            FileLogger? fileLogger = new FileLogger("invalidFile.txt");
            fileLogger.Log(LogLevel.Error, "message");
            
        }

        [TestMethod]
        public void Log_ValidFile_appendToFile()
        {
            LogFactory? lf = new LogFactory();
            lf.ConfigureFileLogger("realFile.txt");
            FileLogger? fileLogger = (FileLogger?)lf.CreateLogger(this.GetType().Name);
            
             
            if(fileLogger != null && !string.IsNullOrEmpty(fileLogger.FilePath))
            {
                fileLogger.Log(LogLevel.Error, "message");
            }
            
            
        }




    }
}
