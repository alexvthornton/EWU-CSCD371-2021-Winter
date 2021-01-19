using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger? baseLogger, string message, params object[] arr)
        {
            if(baseLogger is null)
                throw new ArgumentNullException("BaseLogger is null");
           

            string res = String.Format(message, arr);

            baseLogger.Log(LogLevel.Error, res);
        }

        public static void Warning(this BaseLogger? baseLogger, string message, params object[] arr)
        {
            if(baseLogger is null)
                throw new ArgumentNullException("BaseLogger is null");
           
            string res = String.Format(message, arr);

            baseLogger.Log(LogLevel.Warning, res);
        }

        public static void Information(this BaseLogger? baseLogger, string message, params object[] arr)
        {
            if(baseLogger is null)
                throw new ArgumentNullException("BaseLogger is null");
           
            string res = String.Format(message, arr);
             
            baseLogger.Log(LogLevel.Information, res);
        }

        public static void Debug(this BaseLogger? baseLogger, string message, params object[] arr)
        {
            if(baseLogger is null)
                throw new ArgumentNullException("BaseLogger is null");
           
            string res = String.Format(message, arr);

            baseLogger.Log(LogLevel.Debug, res);
        }

    }
}
