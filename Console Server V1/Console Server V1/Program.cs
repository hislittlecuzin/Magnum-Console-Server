using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Server_V1
{
    class Program
    {
        public static bool loopConsole = true;

        static void Main(string[] args)
        {
            Base.GameControl.StartGame();
            Thread consoleInformation = new Thread(new ThreadStart(ConsoleCommands.ConsoleLoop));
            consoleInformation.Start();

            while (loopConsole) {

            }

            Console.WriteLine("Enter to close.");
            Console.ReadLine();
        }



        

        

    }
}
