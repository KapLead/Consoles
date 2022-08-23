using System;
using System.Collections.Generic;
using System.Linq;
using Consoles;

namespace Examples
{
    public class Program : Consolas
    {
        static void Main(string[] args)
        {
            SetupScreen(140, 40, true);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("AAAAA\r\nBBBB");
            var color = GetColor(1, 1);
            Console.ReadKey();
        }
    }
}
