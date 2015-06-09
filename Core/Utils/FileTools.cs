using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils
{
    public static class FileTools
    {
        
        public static string ReadFileString(string path)
        {
            // Use StreamReader to consume the entire text file.
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        public static string ReadLineString(string path)
        {
            // Use StreamReader to consume the entire text file.
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadLine();
            }
        }

        public static string WriteSingleLine(string path)
        {
            // Write single line to new file.
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                //writer.WriteLine("Important data line 1");
                return writer.ToString();
            }
        }

        
    }
}
