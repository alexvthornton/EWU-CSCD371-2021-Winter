using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Assignment4.Writer
{
    public class SetWriter: IDisposable
    {

        bool disposed = false;

        private StreamWriter? writer;

        public StreamWriter Writer{
            get
            {
                return writer!;
            }
            private set => writer = value??throw new ArgumentNullException();
        }
        public SetWriter(string filePath)
        {
            //null check
            this.writer = new StreamWriter(filePath);
        }

        public void WriteToFile(NumSet numSet)
        {
            //null check
            using(this.Writer)
            {
                this.Writer.WriteLine(numSet.ToString());
            }
        }
        
        // Flag: Has Dispose already been called?
   

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing) {
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
    }
}