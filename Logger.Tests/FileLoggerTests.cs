﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        public void FileLogger()
        {

        LogFactory lf = new LogFactory();

        lf.ConfigureFileLogger("/Users/alexthornton/Documents/College/CSCD371/EWU-CSCD371-2021-Winter/Logger/test.txt");
        FileLogger fileLogger = (FileLogger)lf.CreateLogger(this.GetType().Name);
        
        fileLogger.Error("the message {0}", 42);

        }

    }
}
