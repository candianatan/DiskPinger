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
            // Solicito el delay deseado
            int time = AskForDelay();

            var stopwatch = Stopwatch.StartNew();
            int pings = 0;
            Console.WriteLine("Delay set to " + time);
            Console.WriteLine("Iniciando pings");

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
                    // Si el valor ingresado es menor a 1000ms solicito uno más grande
                    if (Convert.ToInt32(entry) < 1000)
                    {
                        Console.WriteLine("El delay mínimo es de 1 segundo (1000ms). Por favor ingrese un nuevo valor:");
                        AskForDelay();
                    }
                    else
                    {
                        Console.WriteLine("aceptado valor " + entry);
                        return Convert.ToInt32(entry);
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
