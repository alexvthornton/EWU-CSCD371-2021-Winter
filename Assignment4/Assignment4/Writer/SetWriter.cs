using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Assignment4.Writer
{
    public class SetWriter: IDispoable
    {
        private StreamWriter streamWriter;

        public SetWriter(File file)
        {
            this.streamWriter = new StreamWriter(file);
        }

        public WriteToFile(NumSet numSet){
            
        }
        
    }
}