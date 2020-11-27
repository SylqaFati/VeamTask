using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace VeamTask
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Starting file is 26,747 bytes.
                string anyString = File.ReadAllText("TextFile1.txt");

                // Output file is 7,388 bytes.
                CompressStringToFile("new.gz", anyString);
            }
            catch
            {
                Console.WriteLine("Could not compress"); // Could not compress.
            }
        }

        public static void CompressStringToFile(string fileName, string value)
        {
            // Part A: write string to temporary file.
            string temp = Path.GetTempFileName();
            File.WriteAllText(temp, value);

            // Part B: read file into byte array buffer.
            byte[] b;
            using (FileStream f = new FileStream(temp, FileMode.Open))
            {
                b = new byte[f.Length];
                f.Read(b, 0, (int)f.Length);
            }

            // Part C: use GZipStream to write compressed bytes to target file.
            using (FileStream f2 = new FileStream(fileName, FileMode.Create))
            using (GZipStream gz = new GZipStream(f2, CompressionMode.Compress, false))
            {
                gz.Write(b, 0, b.Length);
            }
        }
    }
}
