using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
//using System.Windows.Forms;

namespace DiskPinger
{
    class ReadFromFile
    {
        static void Main()
        {
            var stopwatch = Stopwatch.StartNew();
            int pings = 0;

            while (true)
            {
                Ping();
                pings++;
                Console.WriteLine("Ping number " + pings);
                Thread.Sleep(30000);
                stopwatch.Stop();
                //Console.WriteLine(stopwatch.ElapsedMilliseconds);
                //Console.WriteLine(DateTime.Now.ToLongTimeString());
                
                stopwatch = Stopwatch.StartNew();
            }
        }
        static void Ping()
        {
            // Example #1
            // Read the file as one string.

            
            //MessageBox.Show("Hello, world.");

            try
            {
                string text = System.IO.File.ReadAllText(@"D:\Ping.txt");

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("{0} Exception caught.", e.Message);

                throw;
            }

            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

        }

        
    }
}
