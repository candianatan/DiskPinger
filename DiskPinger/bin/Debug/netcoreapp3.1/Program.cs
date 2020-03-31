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
            int time = AskForDelay();
            var stopwatch = Stopwatch.StartNew();
            int pings = 0;
            Console.WriteLine("Delay set to " + time);

            while (true)
            {
                Ping();
                pings++;
                Console.WriteLine("Ping number " + pings);
                Thread.Sleep(time);
                stopwatch.Stop();
                //Console.WriteLine(stopwatch.ElapsedMilliseconds);
                //Console.WriteLine(DateTime.Now.ToLongTimeString());
                
                stopwatch = Stopwatch.StartNew();
            }
        }


        static int AskForDelay()
        {
            int time = 1000;
            Console.WriteLine("Enter the delay time between pings:");
            string entry = Console.ReadLine();
            try
            {
                //time = Convert.ToInt32(Console.ReadLine());
                if (entry == "")
                {                    
                    Console.WriteLine("The entry can not be understood. Please enter the pause expressed in seconds. Example: \"30\"");
                    AskForDelay();
                    //
                    //Hacer prueba de escritorio de esta parte. Acaso no se produce recursividad? REVISAR!!!!!!!!!!!!
                    //
                }
                else
                {
                    time = Convert.ToInt32(entry);
                }
                if (Convert.ToInt32(entry) < 1000)
                {
                    Console.WriteLine("El delay mínimo es de 1 segundo (1000ms). Por favor ingrese un nuevo valor:");
                    AskForDelay();
                }
            }
            catch (System.InvalidCastException e)
            {
                Console.WriteLine("The entry can not be understood. Exiting...");
                throw;
            }
            catch (System.FormatException f)
            {
                Console.WriteLine("The entry can not be understood. Exiting...");
                //throw;
            }

            return time;
        }


        static void Ping()
        {
            // Example #1
            // Read the file as one string.
            try
            {
                string text = System.IO.File.ReadAllText(@"D:\Ping.txt");
            }
            catch (IOException e)
            {
                Console.WriteLine("{0} Exception caught.", e.Message);
                throw;
            }

            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
        }
    }
}
