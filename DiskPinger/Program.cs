using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
//using System.Windows.Forms;

namespace DiskPinger
{
    class ReadFromFile
    {
        public const string path = @"D:\Ping.txt";
        public const int minDelay = 500;
        public static DateTime startTime = DateTime.Now;
        static void Main()
        {
            // Solicito el delay deseado
            int time = AskForDelay();
            var stopwatch = Stopwatch.StartNew();
            int pings = 0;
            Console.WriteLine("Delay set to " + time);
            Console.WriteLine("Iniciando pings");
            startTime = DateTime.Now;

            while (true)
            {
                Console.WriteLine("Start time: " + startTime.ToString());

                Ping();
                pings++;
                Escribir();
                Console.WriteLine("Ping number " + pings);
                //Console.WriteLine("Elapsed time: " + DateTime.Now.Subtract(startTime).ToString());
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopwatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("Tiempo de ejecución: " + elapsedTime);

                stopwatch.Stop();
                Thread.Sleep(time);

                //Console.WriteLine(stopwatch.ElapsedMilliseconds);
                //Console.WriteLine(DateTime.Now.ToLongTimeString());

                stopwatch = Stopwatch.StartNew();
                Console.Clear();

            }
        }


        static int AskForDelay()
        {
            Console.WriteLine("Enter the delay time between pings:");
            string entry = Console.ReadLine();
            try
            {
                if (entry == "")
                {                    
                    Console.WriteLine("The entry can not be understood. Please enter the delay expressed in miliseconds. Example: \"30000\"");
                    // Solicito delay nuevamente
                    AskForDelay();
                    //
                    //Hacer prueba de escritorio de esta parte. Acaso no se produce recursividad? REVISAR!!!!!!!!!!!!
                    //
                }
                else
                {
                    // Si entry no es "" procedo a convertir el string a entero
                    // return Convert.ToInt32(entry);
                    // Si el valor ingresado es menor a minDelay ms solicito uno más grande
                    if (Convert.ToInt32(entry)*1000 < minDelay)
                    {
                        Console.WriteLine("El delay mínimo es de " + minDelay/1000 + " segundos. Por favor ingrese un nuevo valor:");
                        AskForDelay();
                    }
                    else
                    {
                        Console.WriteLine("aceptado valor " + (Convert.ToInt32(entry) * 1000));
                        return (Convert.ToInt32(entry) * 1000);
                    }
                }

                
            }
            catch (System.InvalidCastException e)
            {
                Console.WriteLine("The entry can not be understood. Exiting...");
                //throw;
            }
            catch (System.FormatException f)
            {
                Console.WriteLine("La información ingresada no se corresponde con un valor numérico. Por favor, ingrese un valor como \"1000\" o \"30000\"");
                // Limpio la consola
                // El metodo Console.Clear() no está funcioando. Revisar documentación para ver cómo hacer la implementación.
                //Clear();

                // Solicito un nuevo valor
                AskForDelay();
                //throw;
            }
            return -1;
        }

        //private static void Clear()
        //{
        //    Limpiar();
        //}

        //public void Limpiar()
        //{
        //    Console.Clear();
        //}

        static void Ping()
        {
            // Example #1
            // Read the file as one string.
            try
            {
                string text = System.IO.File.ReadAllText(path);
            }
            catch (IOException e)
            {
                Console.WriteLine("{0} Exception caught.", e.Message);
                throw;
            }

            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
        }

        static void Escribir()
        {
            // Este método escribe la fecha y hora actual al archivo "path" para generar actividad en el disco
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(DateTime.Now.ToLongTimeString());
            }
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }
    }
}
