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
            Title = "HELLOWORLD";
            Write("HELLO WORD !!!");
            WriteMagic("[#M2,2][#F3]HELL[#F9]O [#F0][#B5]WORLD !!!");
            WriteMagic("[#B0][#M3,3][#F3]H" +
                         "[#M3,4][#F4]E" +
                         "[#M3,5][#F5]L" +
                         "[#M3,6][#F6]L" +
                         "[#M3,7][#F7]O [#F9][#0]WORLD !!!");
            Console.ReadKey();
        }
    }
}
